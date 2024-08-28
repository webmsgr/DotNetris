using System.Collections.Concurrent;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using DotNetris.Network.Server.Database;
using DotNetris.Network.Server.Database.Models;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore;
using DotNetris.Network.Protocol;
using Microsoft.VisualStudio.Threading;

namespace DotNetris.Network.Server;

public class Server
{
    private ServerConfig _conf;

    private Task? serverTask;


    internal CancellationTokenSource cancel = new CancellationTokenSource();
    
    public Server(ServerConfig config)
    {
        config.Validate();
        _conf = config;

    }
    
    
    
    public void RunBackground()
    {
        if (serverTask != null)
        {
            throw new Exception("Server already started");
        }

        serverTask = Task.Run(async () => await this.RunInternal());
        //serverTask.Start();
    }

    public void Run()
    {
        if (serverTask != null)
        {
            throw new Exception("Server already started");
        }

        serverTask = Task.Run(async () => await this.RunInternal());
        //serverTask.Start();
        serverTask.Wait(cancel.Token);
    }

    public void Stop()
    {
        // lol
        if (serverTask == null)
        {
            throw new Exception("Server not started");
        }
        if (!cancel.IsCancellationRequested)
        {
            cancel.Cancel(); // bye bye
        }
    }


    private AsyncQueue<ReplayTaskEntry> ReplayTaskQueue = new AsyncQueue<ReplayTaskEntry>();

    private ConcurrentDictionary<int, byte> LoggedInUsers = new ConcurrentDictionary<int, byte>();
    private async Task ReplayTask(DotNetrisContext ctx, CancellationToken cancel)
    {
        while (!cancel.IsCancellationRequested)
        {
            ReplayTaskEntry next = await ReplayTaskQueue.DequeueAsync(cancel);
            if (cancel.IsCancellationRequested)
            {
                break;
            }
            // todo: check the replay
            
        }
    }

    private async Task RunInternal()
    {
        Console.WriteLine("Hello server!");
        Console.WriteLine("Preparing database!");
        //Console.WriteLine(_conf.ConnectionString);
        await using DotNetrisContext ctx = new DotNetrisContext(_conf.ConnectionString);
        await ctx.Database.MigrateAsync(cancel.Token); // we can use this because there is no scaling.
        
        Console.WriteLine("Starting replay task");
        _ = Task.Run(async () =>
        {
            await using DotNetrisContext replayCtx = new DotNetrisContext(_conf.ConnectionString);
            await ReplayTask(replayCtx, cancel.Token);
        });
        
        // create our stream
        TcpListener channel = new TcpListener(IPAddress.Parse(_conf.host), _conf.port);
        channel.Start();
        Console.WriteLine("Waiting to recieve connections");
        while (!cancel.Token.IsCancellationRequested)
        {

            TcpClient client = await channel.AcceptTcpClientAsync(cancel.Token);
            Console.WriteLine("Got a connection!");
            _ = Task.Run(async () =>
            {
                try
                {
                    await HandleConnection(client, _conf.ConnectionString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failure in connection: {ex.Message}");
                }

            });
        }
    }

    private ChunkedStream CreateRWStream(Stream inner)
    {
        switch (_conf.security)
        {
            case SecurityLevel.None:
                return new ChunkedStream(inner);
            case SecurityLevel.Password:
                ChunkedStream stream = new ChunkedStream(inner, _conf.password!);
                stream.EstablishEncryption();
                return stream;
            case SecurityLevel.TLS:
                SslStream sslStream = new SslStream(inner, false);
                try
                {
                    sslStream.AuthenticateAsServer(_conf.certificate!, false,
                        SslProtocols.Tls12 | SslProtocols.Tls13, true);
                    return new ChunkedStream(sslStream);
                }
                catch (Exception ex)
                {
                    throw new CryptographicException($"SSL connection failed: {ex}");
                }
            default:
                throw new NotImplementedException();
        }
    }

    private async Task HandleConnection(TcpClient _client, string connectionString)
    {
        using TcpClient client = _client;
        using ChunkedStream readWStream = CreateRWStream(client.GetStream());
        await using DotNetrisContext ctx = new DotNetrisContext(connectionString);
        //bool run = true;
        using UserHandle user = new UserHandle(null, this.LoggedInUsers);
        while (true)
        {
            ClientToServerMessage packet = await ReadPacket(readWStream, cancel.Token);
            ServerToClientMessage resp = new ServerToClientMessage();
            switch (packet.PacketCase)
            {
                case ClientToServerMessage.PacketOneofCase.Ping:
                    // well hello to you too
                    resp.Pong = new Pong()
                    {
                        Data = packet.Ping.Data
                    };
                    break;
                case ClientToServerMessage.PacketOneofCase.Login:
                    // login time
                    // check for a user with that username
                    resp = new ServerToClientMessage();
                    var login = packet.Login;
                    var foundUser = await ctx.Users.FirstOrDefaultAsync(u => u.Username == login.Username, cancel.Token);
                    if (foundUser == null)
                    {
                        // no user?
                        resp.GeneralResult = GeneralResult.Failure("Invalid Username/Password");
                        break;
                    }

                    if (Crypto.VerifyPassword(foundUser.Password, login.Password))
                    {
                        if (LoggedInUsers.TryGetValue(foundUser.Id, out byte _))
                        {
                            // this user is already logged in!
                            resp.GeneralResult = GeneralResult.Failure("User already logged in!");
                            break;
                        }
                        user.User = foundUser;
                        resp.GeneralResult = GeneralResult.Success("Successfully logged in");
                    }
                    else
                    {   
                        resp.GeneralResult = GeneralResult.Failure("Invalid Username/Password");
                    }
                    break;
                case ClientToServerMessage.PacketOneofCase.Register:
                    resp = new ServerToClientMessage();
                    var register = packet.Register;
                    var existing = await ctx.Users.FirstOrDefaultAsync(u => u.Username == register.Username, cancel.Token);
                    if (existing != null)
                    {
                        resp.GeneralResult = GeneralResult.Failure("Username taken");
                        break;
                    }

                    var newUser = User.CreateUser(register.Username, register.Password);
                    ctx.Users.Add(newUser);
                    user.User = newUser;
                    await ctx.SaveChangesAsync(cancel.Token);
                    resp.GeneralResult = GeneralResult.Success("Successfully registered and logged in!");
                    break;
                case ClientToServerMessage.PacketOneofCase.DeleteAccount:
                    if (user.User == null)
                    {
                        resp.GeneralResult = GeneralResult.Failure("Not logged in");
                        break;
                    }
                    // check password
                    if (!Crypto.VerifyPassword(user.User.Password, packet.DeleteAccount.Password))
                    {
                        resp.GeneralResult = GeneralResult.Failure("Invalid password");
                        break;
                    }
                    ctx.Users.Remove(user.User);
                    await ctx.SaveChangesAsync(cancel.Token);
                    resp.GeneralResult = GeneralResult.Success("Account deleted");
                    user.User = null;
                    break;
                case ClientToServerMessage.PacketOneofCase.ChangePassword: 
                    if (user.User == null)
                    {
                        resp.GeneralResult = GeneralResult.Failure("Not logged in");
                        break;
                    }
                    // check password
                    if (!Crypto.VerifyPassword(user.User.Password, packet.ChangePassword.OldPassword))
                    {
                        resp.GeneralResult = GeneralResult.Failure("Invalid password");
                        break;
                    }
                    user.User.Password = Crypto.HashPassword(packet.ChangePassword.NewPassword);
                    await ctx.SaveChangesAsync(cancel.Token);
                    resp.GeneralResult = GeneralResult.Success("Password changed");
                    break;
                default:
                    throw new NotImplementedException($"Packet type not implemented: {packet.PacketCase}");
            }

            WritePacket(readWStream, resp);
            
        }
    }

    private static void WritePacket(ChunkedStream stream, ServerToClientMessage message)
    {

        byte[] data = message.ToByteArray();
        stream.WriteChunk(data);
    }

    private static async Task<ClientToServerMessage> ReadPacket(ChunkedStream stream, CancellationToken token)
    {
        byte[] data = await stream.ReadChunkAsync(token);
        return ClientToServerMessage.Parser.ParseFrom(data);
    }
    
}