using System.Text;

namespace DotNetris;

public static class Crypto
{

    public const int Argon2IdIterations = 3;
    public const int Argon2IdMemorySize = 67108864;
    
    
    /// <summary>
    /// Securely hash a password with Argon2id
    /// </summary>
    /// <param name="password">Password to hash</param>
    /// <returns>The hashed password</returns>
    public static string HashPassword(string password)
    {
        byte[] bytePassword = Encoding.UTF8.GetBytes(password);
        Span<byte> output = stackalloc byte[Geralt.Argon2id.MaxHashSize]; 
        Geralt.Argon2id.ComputeHash(output, bytePassword.AsSpan(), Argon2IdIterations, Argon2IdMemorySize); 
        return Encoding.UTF8.GetString(output);
    }
    /// <summary>
    /// Verify a password matches a hash
    /// </summary>
    /// <param name="hash">Hashed password</param>
    /// <param name="password">Password to check</param>
    /// <returns>True if the password matches, false otherwise.</returns>
    public static bool VerifyPassword(string hash, string password)
    {
        byte[] bytePassword = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = Encoding.UTF8.GetBytes(hash);
        return Geralt.Argon2id.VerifyHash(hashBytes.AsSpan(), bytePassword.AsSpan());
    }
}