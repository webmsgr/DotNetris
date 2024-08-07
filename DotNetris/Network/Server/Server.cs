using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using Google.Protobuf;

namespace DotNetris.Network.Server;

public class Server
{
    private ServerConfig _conf;

    private Thread? serverThread;
    
    public Server(ServerConfig config)
    {
        config.Validate();
        _conf = config;

    }
    
    
    
    public void RunBackground()
    {
        if (serverThread != null)
        {
            throw new Exception("Server already started");
        }
        serverThread = new Thread(this.RunInternal);
        serverThread.Start();
    }

    public void Run()
    {
        if (serverThread != null)
        {
            throw new Exception("Server already started");
        }
        serverThread = new Thread(this.RunInternal);
        serverThread.Start();
        serverThread.Join();
    }

    public void Stop()
    {
        // lol
        if (serverThread == null)
        {
            throw new Exception("Server not started");
        }
    }

    private void RunInternal()
    {
        // create our stream
        TcpListener channel = new TcpListener(IPAddress.Parse(_conf.host), _conf.port);
        channel.Start();
        while (true)
        {
            TcpClient client = channel.AcceptTcpClient();
            Task.Run(async () =>
            {
                await HandleConnection(client);
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
    
    private async Task HandleConnection(TcpClient _client)
    {
        using TcpClient client = _client;
        using ChunkedStream readWStream = CreateRWStream(client.GetStream());
        //bool run = true;
        while (true)
        {
            ClientToServerMessage packet = await Task.Run(() => ReadPacket(readWStream));
            ServerToClientMessage? resp;
            switch (packet.PacketCase)
            {
                case ClientToServerMessage.PacketOneofCase.Ping:
                    // well hello to you too
                    resp = new ServerToClientMessage();
                    resp.Pong = new Pong()
                    {
                        Data = packet.Ping.Data
                    };
                    break;
                default:
                    throw new NotImplementedException($"Packet type not implemented: {packet.PacketCase}");
            }

            if (resp != null)
            {
                await Task.Run(() => WritePacket(readWStream, resp));
            }
        }
    }

    private static void WritePacket(ChunkedStream stream, ServerToClientMessage message)
    {

        byte[] data = message.ToByteArray();
        stream.WriteChunk(data);
    }

    private static ClientToServerMessage ReadPacket(ChunkedStream stream)
    {
        byte[] data = stream.ReadChunk();
        return ClientToServerMessage.Parser.ParseFrom(data);
    }
    
}