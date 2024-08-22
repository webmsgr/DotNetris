using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetris.Network.Server.Database.Models;

public class User
{
    /// <summary>
    /// The user's ID
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The user's username
    /// </summary>
    public string Username { get; set; }
    
    
    /// <summary>
    /// The user's password hashed with argon2id
    /// </summary>
    
    public string Password { get; set; }
    /// <summary>
    /// A 64 byte token used to validate replays
    /// 
    /// Generated when starting a new game online, and is used to prevent uploading the same replay multiple times
    /// 
    /// Null if no token has been issued
    /// </summary>
    public byte[]? GameToken { get; set; }
    
    /// <summary>
    /// The key used to sign replays for this user
    /// 
    /// Each user is special and gets their own key
    /// </summary>
    public byte[] UserKey { get; set; }


    /// <summary>
    /// Create a new user with a username and password
    /// </summary>
    /// <param name="username">The username</param>
    /// <param name="password">The password</param>
    /// <returns>A fully created User object</returns>
    public static User CreateUser(string username, string password)
    {

        Span<byte> keyingAndSalt = stackalloc byte[Geralt.BLAKE2b.MaxKeySize + Geralt.BLAKE2b.SaltSize];
        Geralt.SecureRandom.Fill(keyingAndSalt);

        var UserKey = new byte[Geralt.BLAKE2b.MaxKeySize]; // 512 bit keys are not overkill at all
        Geralt.BLAKE2b.DeriveKey(UserKey, 
            keyingAndSalt[..Geralt.BLAKE2b.MaxKeySize], 
            "DOTNETRIS YAY!!!"u8,
            keyingAndSalt[Geralt.BLAKE2b.MaxKeySize..]
            );
        return new User()
        {
            Username = username,
            Password = Crypto.HashPassword(password),
            GameToken = null,
            UserKey = UserKey
        };
    }
}


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        

        builder
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(16)
            .IsUnicode(); // no funny 
        
        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(Geralt.Argon2id.MaxHashSize);

        builder
            .Property(u => u.GameToken)
            .HasMaxLength(64)
            .IsFixedLength();

        builder
            .HasIndex(["Username"], "username_index")
            .IsUnique();

        builder
            .Property(u => u.GameToken)
            .HasMaxLength(Geralt.BLAKE2b.MaxKeySize)
            .IsFixedLength();
    }
}