using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonopolyKata
{
    [TestClass]
    public class MonopolyTest
    {
        private Monopoly monopoly = new Monopoly();

        [TestMethod]
        public void TestDistinctOrder()
        {
            Assert.AreEqual(10, monopoly.DistinctOrder());
        }

        [TestMethod]
        public void TestFullGame()
        {
            var player1Money = monopoly.GetPlayer(1).accountBalance;

            Assert.AreNotEqual(0, player1Money);
        }

    }
}
