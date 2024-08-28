// See https://aka.ms/new-console-template for more information
namespace DotNetris.Server;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CommandLine;
using DotNetris.Network;

using DotNetris.Network.Server;

internal static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<ServerArguments>(args)
            .WithParsed((arguments => Server(arguments)));
    }
    static void Server(ServerArguments args)
    {
        // what security level do we need
        SecurityLevel level = SecurityLevel.None;
        X509Certificate? certificate = null;
        byte[]? password = null;
        if (args.Password != null)
        {
            level = SecurityLevel.Password;
            password = Encoding.UTF8.GetBytes(args.Password);
        }
        else if (args.CertPath != null)
        {
            // try and load it
            certificate = X509Certificate.CreateFromCertFile(args.CertPath);
            level = SecurityLevel.Password;
        }
            
        // create a server config
        ServerConfig conf = new ServerConfig()
        {
            host = args.Host,
            port = args.Port,
            security = level,
            password = password,
            certificate = certificate,
            ConnectionString = args.DB
        };
        Console.Out.WriteLine($"Starting server on {args.Host}:{args.Port}");
        var server = new Server(conf);
        server.Run();
    }
}

