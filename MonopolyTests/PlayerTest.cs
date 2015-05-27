using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTest
    {
        public Player player1 = new Player();

        [TestMethod]
        public void TestLocationUpdated()
        {
            var tempLocation = player1.GetCurrentLocation();
            player1.RollDicePair();
            Assert.AreNotEqual(tempLocation, player1.GetCurrentLocation());
        }

        [TestMethod]
        public void TestDiceRoll()
        {
            Assert.IsTrue(player1.RollDicePair() >= 1 || player1.RollDicePair() <= 12);
        }
        
        [TestMethod]
        public void TestGoToJail()
        {
            var currentLocation = player1.currentLocation = 30;
            player1.AdjustAccountFunds(currentLocation);
            var justVisiting = player1.GetCurrentLocation();
            Assert.AreEqual(41, justVisiting);
        }

        [TestMethod]
        public void TestLandGo()
        {
            var currentLocation = player1.currentLocation = 0;
            player1.AdjustAccountFunds(currentLocation);
            var accountBalance = player1.GetAccountBalance();
            Assert.AreEqual(200, accountBalance);
        }

        [TestMethod]
        public void TestPassGo()
        {
            var currentLocation = player1.currentLocation = 40;
            player1.RollDicePair();
            var accountBalance = player1.GetAccountBalance();
            Assert.AreEqual(200, accountBalance);
        }

        [TestMethod]
        public void TestIncomeTax200()
        {
            player1.accountBalance = 1000;
            var currentLocation = player1.currentLocation = 4;
            player1.AdjustAccountFunds(currentLocation);
            var accountBalance = player1.GetAccountBalance();
            Assert.AreEqual(800, accountBalance);
        }

        [TestMethod]
        public void TestIncomeTax20Percent()
        {
            player1.accountBalance = 60;
            var currentLocation = player1.currentLocation = 4;
            player1.AdjustAccountFunds(currentLocation);
            var accountBalance = player1.GetAccountBalance();
            Assert.AreEqual(48, accountBalance);
        }

        [TestMethod]
        public void TestLuxuryTax()
        {
            player1.accountBalance = 1000;
            var currentLocation = player1.currentLocation = 38;
            player1.AdjustAccountFunds(currentLocation);
            var accountBalance = player1.GetAccountBalance();
            Assert.AreEqual(925, accountBalance);
        }
    }
}
