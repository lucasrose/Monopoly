using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonopolyKata
{
    [TestClass]
    public class MonopolyTest                                                                           //Total Usage For Class: 1 Objects Created
                                                                                                        //                       5 Accessed
    {
        private Monopoly monopoly = new Monopoly();
        private Player player1;                                                                        //Method Calls To Another Class: 4 (Same Method)
        private Player player2;
        private Player player3;
        private Player player4;

        [TestInitialize]
        public void SetUp()
        {
            player1 = monopoly.GetPlayer(1);
            player2 = monopoly.GetPlayer(2);
            player3 = monopoly.GetPlayer(3);
            player4 = monopoly.GetPlayer(4);
        }

        [TestMethod]
        public void TestDistinctOrder()                                                                 //Total Usage For Method: 1/5 Objects
        {
            Assert.AreEqual(10, monopoly.DistinctOrder());
        }

        [TestMethod]
        public void TestFullGame()                                                                     //Total Usage For Method: 2/5 Objects
        {                                                                                              //Method Calls 2/4
            var player1Money = monopoly.GetPlayer(1).AccountBalance;

            Assert.AreNotEqual(0, player1Money);
        }

        [TestMethod]
        public void TestMultiplierAccountFluctuationPlayer1()                                           //Total Usage For Method: 2/5 Objects
        {                                                                                               //Method Calls 2
            var balanceBefore = player1.AccountBalance;                                                 
            monopoly.RunMonopoly(3);
            var balanceAfter = player1.AccountBalance;
            Assert.AreNotEqual(balanceBefore, balanceAfter);
        }

        [TestMethod]
        public void TestMultiplierAccountFluctuationPlayer2()                                           //Total Usage For Method: 2/5 Objects
        {                                                                                               //Method Calls 2
            var balanceBefore = player2.AccountBalance;
            monopoly.RunMonopoly(3);
            var balanceAfter = player2.AccountBalance;
            Assert.AreNotEqual(balanceBefore, balanceAfter);
        }

        [TestMethod]
        public void TestMultiplierAccountFluctuationPlayer3()                                           //Total Usage For Method: 2/5 Objects
        {                                                                                               //Method Calls 2
            var balanceBefore = player3.AccountBalance;
            monopoly.RunMonopoly(3);
            var balanceAfter = player3.AccountBalance;
            Assert.AreNotEqual(balanceBefore, balanceAfter);
        }

        [TestMethod]
        public void TestMultiplierAccountFluctuationPlayer4()                                           //Total Usage For Method: 2/5 Objects
        {                                                                                               //Method Calls 2
            var balanceBefore = player4.AccountBalance;
            monopoly.RunMonopoly(3);
            var balanceAfter = player4.AccountBalance;
            Assert.AreNotEqual(balanceBefore, balanceAfter);
        }

    }
}
