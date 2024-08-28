using System.Diagnostics;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using Google.Protobuf;
using DotNetris.Network.Protocol;

namespace DotNetris.Network.Client;

public class Client
{
    private ClientConfig _conf;
    
    private ChunkedStream? stream;

    
    public bool IsConnected { get; private set; }
    public bool LoggedIn { get; private set;  }
    
    private TcpClient? tcp;
    public Client(ClientConfig config)
    {
        config.Validate();
        _conf = config;
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
                    sslStream.AuthenticateAsClient(_conf.host);
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

    public void Close()
    {
        if (stream != null)
        {
            stream.Dispose();
            stream = null;
            tcp = null;
            IsConnected = false;
        }
    }
    
    public void Connect()
    {
        // open a TCP connection
        Console.WriteLine("Connecting to server...");
        var connectWatch = Stopwatch.StartNew();
        var client = new TcpClient(_conf.host, _conf.port);
        connectWatch.Stop();
        
        // oh boy!
        // wrap it
        var createStream = Stopwatch.StartNew();
        stream = CreateRWStream(client.GetStream());
        createStream.Stop();
        Console.WriteLine("Connected to server in " +
                          $"{connectWatch.ElapsedMilliseconds + createStream.ElapsedMilliseconds}ms " +
                          $"({connectWatch.ElapsedMilliseconds}ms tcp, {createStream.ElapsedMilliseconds}ms establish)");
        Ping();
        IsConnected = true;
    }
/// <summary>
/// Send a ping to the server
/// </summary>
/// <exception cref="Exception">If something goes wrong</exception>
    public void Ping()
    {
        if (stream == null)
        {
            throw new Exception("Client is not connected");
        }
        var pingData = new byte[64];
        Geralt.SecureRandom.Fill(pingData);
        ClientToServerMessage packet = new ClientToServerMessage
        {
            Ping = new Ping()
            {
                Data = ByteString.CopyFrom(pingData)
            }
        };
        var resp = SendRecv(packet);
        if (resp.PacketCase != ServerToClientMessage.PacketOneofCase.Pong)
        {
            throw new Exception($"Invalid response from the server. Expected Pong, got {resp.PacketCase}");
        }

        if (!resp.Pong.Data.SequenceEqual(pingData))
        {
            throw new Exception("Server Pong contained invalid data");
        }
    }

    /// <summary>
    /// Try and login to the server
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <returns>The success message</returns>
    /// <exception cref="Exception">If something goes wrong</exception>
    public string Login(string username, string password)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            Login = new Login()
            {
                Username = username,
                Password = password
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.GeneralResult:
                if (resp.GeneralResult.ResultCase == GeneralResult.ResultOneofCase.Ok)
                {
                    LoggedIn = true;
                }
                return resp.GeneralResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }
    /// <summary>
    /// Try and register on the server
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <returns>The success message</returns>
    /// <exception cref="Exception">If something goes wrong</exception>
    public string Register(string username, string password)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            Register = new Register()
            {
                Username = username,
                Password = password
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.GeneralResult:
                if (resp.GeneralResult.ResultCase == GeneralResult.ResultOneofCase.Ok)
                {
                    LoggedIn = true;
                }
                return resp.GeneralResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }

    /// <summary>
    /// Fetches all entries from start-end in the leaderboard
    /// </summary>
    /// <param name="start">Starting position</param>
    /// <param name="end">Ending position</param>
    /// <returns>The leaderboard entries</returns>
    /// <exception cref="Exception">Server error</exception>
    public ReplayEntry[] FetchLeaderboard(int start, int end)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            Leaderboard = new FetchLeaderboard()
            {
                End = end,
                Start = start
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.LeaderboardResult:
                return resp.LeaderboardResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }
    /// <summary>
    /// Request a signed game settings from the server
    /// </summary>
    /// <param name="settings">The game settings to sign</param>
    /// <returns>The signed game settings</returns>
    /// <exception cref="Exception">Server errors</exception>
    public SignedGameSettings RequestGame(GameSettings settings)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            RequestGame = new RequestGame()
            {
                Settings = settings
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.RequestGameResult:
                return resp.RequestGameResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }
    /// <summary>
    /// Upload a replay to the server
    /// </summary>
    /// <param name="settings">The signed game settings, requested from Client.RequestGame</param>
    /// <param name="inputs">The replay data</param>
    /// <returns>A string containing a success message</returns>
    /// <exception cref="Exception">On server error</exception>
    public string UploadReplay(SignedGameSettings settings, Inputs[] inputs)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            UploadReply = new UploadReplay()
            {
                Replay = new Replay()
                {
                    Replay_ = ByteString.CopyFrom(
                        inputs.Select(i => (byte)i)
                            .ToArray()
                        ),
                    Tag = settings
                }
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.GeneralResult:
                return resp.GeneralResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }
    /// <summary>
    /// Deletes the current user's account. The user's current password is required.
    /// </summary>
    /// <param name="password">The user's current password</param>
    /// <returns>A success message</returns>
    /// <exception cref="Exception">On server error</exception>
    public string DeleteAccount(string password)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            DeleteAccount = new DeleteAccount()
            {
                Password = password
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.GeneralResult:
                if (resp.GeneralResult.ResultCase == GeneralResult.ResultOneofCase.Ok)
                {
                    LoggedIn = false;
                }
                return resp.GeneralResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }
/// <summary>
/// Change the user's password. Requires the user's old password
/// </summary>
/// <param name="oldPassword">Old password</param>
/// <param name="newPassword">New password</param>
/// <returns> A success message </returns>
/// <exception cref="Exception">On server error</exception>
    public string ChangePassword(string oldPassword, string newPassword)
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            ChangePassword = new ChangePassword()
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            }
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.GeneralResult:
                return resp.GeneralResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }


    /*public ReplayList GetMyReplays()
    {
        ClientToServerMessage packet = new ClientToServerMessage
        {
            GetReplays = new GetMyReplays()
        };
        var resp = SendRecv(packet);
        switch (resp.PacketCase)
        {
            case ServerToClientMessage.PacketOneofCase.ReplayListResult:
                return resp.ReplayListResult.Unwrap();
            default:
                throw new Exception("Invalid response packet");
        }
    }*/
    
    private ServerToClientMessage SendRecv(ClientToServerMessage message)
    {
        Console.WriteLine($" -> {message.PacketCase}");
        var packetTimer = Stopwatch.StartNew();
        if (stream == null)
        {
            throw new Exception("Not connected!");
        }
        WritePacket(stream, message);
        var result = ReadPacket(stream);
        packetTimer.Stop();
        if (result.PacketCase == ServerToClientMessage.PacketOneofCase.GeneralResult)
        {
            // we gotta print the actual result
            if (result.GeneralResult.ResultCase == GeneralResult.ResultOneofCase.Ok)
            {
                Console.WriteLine($" <- Ok('{result.GeneralResult.Ok.Message}') in {packetTimer.ElapsedMilliseconds}ms");
            }
            else
            {
                Console.WriteLine($" <- Fail('{result.GeneralResult.Fail.Message}') in {packetTimer.ElapsedMilliseconds}ms");
            }
        }
        else
        {
            Console.WriteLine($" <- {result.PacketCase} in {packetTimer.ElapsedMilliseconds}ms");
        }
        
        return result;
    }
    
    private static void WritePacket(ChunkedStream stream, ClientToServerMessage message)
    {

        byte[] data = message.ToByteArray();
        stream.WriteChunk(data);
    }

    private static ServerToClientMessage ReadPacket(ChunkedStream stream)
    {
        byte[] data = stream.ReadChunk();
        return ServerToClientMessage.Parser.ParseFrom(data);
    }
}