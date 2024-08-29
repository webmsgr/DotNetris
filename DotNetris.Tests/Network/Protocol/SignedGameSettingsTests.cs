using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetris.Network.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetris.Network.Server.Database.Models;

namespace DotNetris.Network.Protocol.Tests
{
    [TestClass()]
    public class SignedGameSettingsTests
    {
        [TestMethod()]
        public void SignAndVerify_Valid_ReturnsTrue()
        {
            var user = User.CreateUser("username", "password");

            // generate an unsigned game settings
            GameSettings settings = new GameSettings()
            {
                Difficulty = Difficulty.Hard
            };
            // sign it
            var signedSettings = SignedGameSettings.Sign(settings, user);


            // make sure it verifies correctly
            Assert.IsTrue(signedSettings.Verify(user));
        }
        [TestMethod()]
        public void SignAndVerify_DifferentUser_ReturnsFalse()
        {
            var user1 = User.CreateUser("username", "password");
            var user2 = User.CreateUser("username", "password");

            // generate an unsigned game settings
            GameSettings settings = new GameSettings()
            {
                Difficulty = Difficulty.Hard
            };
            // sign it
            var signedSettings = SignedGameSettings.Sign(settings, user1);


            // make sure it verifies correctly
            Assert.IsFalse(signedSettings.Verify(user2));
        }
        [TestMethod()]
        public void SignAndVerify_SameUserTwice_ReturnsFalse()
        {
            var user1 = User.CreateUser("username", "password");

            // generate an unsigned game settings
            GameSettings settings = new GameSettings()
            {
                Difficulty = Difficulty.Hard
            };
            // sign it
            var signedSettings = SignedGameSettings.Sign(settings, user1);


            // make sure it verifies correctly
            Assert.IsTrue(signedSettings.Verify(user1));
            Assert.IsFalse(signedSettings.Verify(user1));
        }
        [TestMethod()]
        public void SignAndVerify_RequestTwoGames_ReturnsFalse()
        {
            var user1 = User.CreateUser("username", "password");

            // generate an unsigned game settings
            GameSettings settings = new GameSettings()
            {
                Difficulty = Difficulty.Hard
            };
            // sign it
            var signedSettings1 = SignedGameSettings.Sign(settings, user1);
            var signedSettings2 = SignedGameSettings.Sign(settings, user1);


            // make sure it verifies correctly
            Assert.IsFalse(signedSettings1.Verify(user1));
            Assert.IsTrue(signedSettings2.Verify(user1));
        }
    }
}