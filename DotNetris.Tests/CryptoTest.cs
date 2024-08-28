namespace DotNetris.Tests;

[TestClass]
public class CryptoTest
{

    [TestMethod]
    public void HashPasswordVerifyPassword_ValidPassword_ReturnsTrue()
    {
        string password = "This is not a leaked secret this is a test";
        string hash = Crypto.HashPassword(password);
        Assert.IsTrue(Crypto.VerifyPassword(hash, password), "VerifyPassword failed even when passed the correct password");
    }
    [TestMethod]
    public void HashPasswordVerifyPassword_InvalidPassword_ReturnsFalse()
    {
        string password = "This is not a leaked secret this is a test";
        string hash = Crypto.HashPassword(password);
        Assert.IsFalse(Crypto.VerifyPassword(hash, "This is a different password"), "VerifyPassword succeeded even with an invalid password");
    }
}