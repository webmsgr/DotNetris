using DotNetris.Network.Server.Database.Models;

namespace DotNetris.Tests.Network.Server.Database.Models;

[TestClass]
public class UserTest
{

    [TestMethod]
    public void User_Create_Works()
    {
        var user = User.CreateUser("Test", "password");
        // yeah thats a user alright
        Assert.AreNotEqual(user.Password, "password"); // did it get hashed
        throw new NotImplementedException();
    }
}