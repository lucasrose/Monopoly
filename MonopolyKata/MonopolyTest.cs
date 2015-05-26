using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonopolyKata
{
    [TestClass]
    public class MonopolyTest
    {
        private Monopoly monopoly = new Monopoly();
        //what do i need to test?


        //test initial player location is 0

        //test random order (varies each time)


        [TestMethod]
        public void TestDistinctOrder()
        {
            Assert.AreEqual(10, monopoly.DistinctOrder());
        }


    }
}
