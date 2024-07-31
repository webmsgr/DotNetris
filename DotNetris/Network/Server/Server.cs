using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;

namespace DotNetris.Network.Server;

public class Server
{
    private ServerConfig _conf;
    public Server(ServerConfig config)
    {
        config.Validate();
        _conf = config;

    }
    public void RunBackground()
    {
        Task.Run(RunInternal);
    }

    public void RunForeground()
    {
        Task.Run(RunInternal).Wait();
    }

    private async void RunInternal()
    {
        // create our stream
        TcpListener channel = new TcpListener(IPAddress.Parse(_conf.host), _conf.port);
        channel.Start();
        while (true)
        {
            TcpClient client = await channel.AcceptTcpClientAsync();
            HandleConnection(client);
        }
    }

    private async void HandleConnection(TcpClient client)
    {
        Stream readWStream;
        switch (_conf.security)
        {
            case SecurityLevel.None:
            case SecurityLevel.Password:
                readWStream = client.GetStream();
                break;
            case SecurityLevel.TLS:
                SslStream stream = new SslStream(client.GetStream(), false);
                try
                {
                    await stream.AuthenticateAsServerAsync(_conf.certificate!, false,
                        SslProtocols.Tls12 | SslProtocols.Tls13, true);
                    readWStream = stream;
                }
                catch (Exception ex)
                {
                    // bye bye
                    return;
                }

                break;
            default:
                throw new NotImplementedException();
        }

        


    }
}