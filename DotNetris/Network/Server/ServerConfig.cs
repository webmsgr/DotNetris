using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace DotNetris.Network.Server;

public class ServerConfig
{
    public required string host;

    public required ushort port;

    /// <summary>
    /// Security level to use. It is recommended to at least use Password-Level security
    /// </summary>
    public required SecurityLevel security;


    public readonly X509Certificate? certificate;

    public readonly byte[]? password;


    public void Validate()
    {
        if (security == SecurityLevel.TLS && certificate == null)
        {
            throw new ArgumentException("A certificate is required when using TLS");
        }
        else if (security == SecurityLevel.Password && password == null)
        {
            throw new ArgumentException("A password is required when using Password Security.");
        }
    }
}