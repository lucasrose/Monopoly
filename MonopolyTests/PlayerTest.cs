using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTest                                                                                 //Total Usage For Class: 2 Objects
    {
        public Player Player1 = new Player();
        public Board GameBoard = new Board();

        [TestMethod]
        public void TestLocationUpdated()                                                                   //Total Usage For Method: 2/2 Objects
        {
            var tempLocation = Player1.GetCurrentLocation();
            Player1.RollDicePair(GameBoard);
            Assert.AreNotEqual(tempLocation, Player1.GetCurrentLocation());
        }

        [TestMethod]
        public void TestRollDice()                                                                          //Total Usage For Method: 2/2  Objects
        {
            Assert.IsTrue(Player1.RollDicePair(GameBoard) >= 1 || Player1.RollDicePair(GameBoard) <= 12);
        }

        [TestMethod]
        public void TestLandGo()                                                                            //Total Usage For Method: 2/2 Objects
        {
            var currentLocation = Player1.CurrentLocation = 0;
            Player1.BasicAccountTransfers(currentLocation, GameBoard);
            var accountBalance = Player1.GetAccountBalance();
            Assert.AreEqual(200, accountBalance);
        }

        [TestMethod]
        public void TestPassGo()                                                                            //Total Usage For Method: 2/2 Objects
        {
            var currentLocation = Player1.CurrentLocation = 40;
            Player1.RollDicePair(GameBoard);
            var accountBalance = Player1.GetAccountBalance();
            Assert.AreEqual(200, accountBalance);
        }

                                                                      //changing with Release 4
         [TestMethod]
        public void TestGoToJail()
        {
            var currentLocation = Player1.CurrentLocation = 31;
            Player1.BasicAccountTransfers(currentLocation, GameBoard);
            var justVisiting = Player1.GetCurrentLocation();
            Assert.AreEqual(10, justVisiting);
        }

        [TestMethod]
        public void TestIncomeTax200()
        {
            Player1.AccountBalance = 1000;
            var currentLocation = Player1.CurrentLocation = 4;
            Player1.BasicAccountTransfers(currentLocation, GameBoard);
            var accountBalance = Player1.GetAccountBalance();
            Assert.AreEqual(800, accountBalance);
        }

        [TestMethod]
        public void TestIncomeTax20Percent()
        {
            Player1.AccountBalance = 60;
            var currentLocation = Player1.CurrentLocation = 4;
            Player1.BasicAccountTransfers(4, GameBoard);
            var accountBalance = Player1.GetAccountBalance();
            Assert.AreEqual(48, accountBalance);
        }

        [TestMethod]
        public void TestLuxuryTax()
        {
            Player1.AccountBalance = 1000;
            var currentLocation = Player1.CurrentLocation = 38;
            Player1.BasicAccountTransfers(currentLocation, GameBoard);
            var accountBalance = Player1.GetAccountBalance();
            Assert.AreEqual(925, accountBalance);
        }

    }
}
