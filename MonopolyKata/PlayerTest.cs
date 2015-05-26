using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonopolyKata
{
    [TestClass]
    public class PlayerTest
    {
        public Player player1 = new Player();

         [TestMethod]
        public void TestLocationUpdated()
        {
            var tempLocation = player1.getCurrentLocation();
            player1.rollDicePair();
            Assert.AreNotEqual(tempLocation, player1.getCurrentLocation());
        }

        [TestMethod]
        public void TestDiceRoll()
        {
            Assert.IsTrue(player1.rollDicePair() >= 1 || player1.rollDicePair() <= 12);
        }

       
    }
}
