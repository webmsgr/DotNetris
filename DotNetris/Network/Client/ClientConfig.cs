namespace DotNetris.Network.Client;

public class ClientConfig
{
    public required string host;

    public required ushort port;

    /// <summary>
    /// Security level to use. It is recommended to at least use Password-Level security
    /// </summary>
    public required SecurityLevel security;
    
    public byte[]? password;
    
    public void Validate()
    { 
        if (security == SecurityLevel.Password && password == null)
        {
            throw new ArgumentException("A password is required when using Password Security.");
        }
    } 
}