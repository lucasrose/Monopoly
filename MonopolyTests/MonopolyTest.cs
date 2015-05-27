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


    }
}
