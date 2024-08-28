using CommandLine;

namespace DotNetris.Server;
[Verb("server", HelpText = "Start a server")]
public class ServerArguments
{
    [Option("Host", Required = true, HelpText = "Hostname to listen on")]
    public string Host { get; set; }
    [Option("Port", Required = true, HelpText = "Port to listen on")]
    public ushort Port { get; set; }
    
    [Option("Password", HelpText = "Password to use for connections. Sets security level to Medium", SetName = "Security")]
    public string? Password { get; set; }
    [Option("Cert", HelpText = "Path to a PKCS#7 X509Certificate to use. Sets security level to High", SetName = "Security")]
    public string? CertPath { get; set; }
    
    [Option("DB", Required = true, HelpText = "Connection string to a MSSQL database")]
    public string DB { get; set; }
}