using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using System.Collections.Generic;

namespace MonopolyTests
{
    [TestClass]
    public class CardStacksTest
    {
        private CardStacks stacks = new CardStacks();
        public List<Cards> NewChanceCards;
        public List<Cards> NewCommunityCards;

        public Stack<Cards> ChanceDeck;
        public Stack<Cards> CommunityDeck;

        //public List<Cards> UsedChanceCards;
        //public List<Cards> UsedCommunityCards;

        [TestInitialize]
        public void SetUp()
        {
            NewChanceCards = stacks.NewChanceCards;
            NewCommunityCards = stacks.NewCommunityCards;

            ChanceDeck = stacks.ChanceDeck;
            CommunityDeck = stacks.CommunityDeck;

            //UsedChanceCards = stacks.UsedChanceCards;
            //UsedCommunityCards = stacks.UsedCommunityCards;
        }
        [TestMethod]
        public void TestShuffleChanceCards()
        {
            var oldCard = NewChanceCards[0];
            stacks.ShuffleOfCards(NewChanceCards, 5);
            Assert.AreNotEqual(oldCard, NewChanceCards[0]);
        }

        [TestMethod]
        public void TestShuffleCommunityCards()
        {
            var oldCard = NewCommunityCards[0];
            stacks.ShuffleOfCards(NewCommunityCards, 5);
            Assert.AreNotEqual(oldCard, NewCommunityCards[0]);
        }

        [TestMethod]
        public void TestStackOfChanceCardsIsNotNull()
        {
            Assert.IsNotNull(ChanceDeck);
        }

        [TestMethod]
        public void TestStackOfCommunityCardsIsNotNull()
        {
            Assert.IsNotNull(CommunityDeck);
        }

        [TestMethod]
        public void TestSizeOfChanceDeck()
        {
            Assert.AreEqual(16, stacks.ChanceDeckSize);
        }

        [TestMethod]
        public void TestSizeOfCommunityDeck()
        {
            Assert.AreEqual(15, stacks.CommunityDeckSize);
        }

        [TestMethod]
        public void TestTakeCardOffChanceDeck()
        {
            var topItem = stacks.TakeCardOffStack(ChanceDeck, Location.CHANCE);
            Assert.AreNotEqual(ChanceDeck.Pop(), topItem);

        }

        [TestMethod]
        public void TestTakeCardOffCommunityDeck()
        {
            var topItem = stacks.TakeCardOffStack(CommunityDeck, Location.COMMUNITY_CHEST);
            Assert.AreNotEqual(CommunityDeck.Pop(), topItem);
        }

        [TestMethod]
        public void TestChanceDeckSizeDecreases()
        {
            TestTakeCardOffChanceDeck();
            Assert.AreEqual(15, stacks.ChanceDeckSize);
        }

        [TestMethod]
        public void TestCommunityDeckSizeDecreases()
        {
            TestTakeCardOffCommunityDeck();
            Assert.AreEqual(14, stacks.CommunityDeckSize);
        }

        [TestMethod]
        public void TestEmptyDeckOfChanceCards()
        {
            var i = 16;
            while (i > 0)
            {
                stacks.TakeCardOffStack(ChanceDeck, Location.CHANCE);
                i--;
            }
            Assert.AreEqual(0, stacks.ChanceDeckSize);
        }

        [TestMethod]
        public void TestEmptyDeckOfCommunityCards()
        {
            var i = 15;
            while (i > 0)
            {
                stacks.TakeCardOffStack(CommunityDeck, Location.COMMUNITY_CHEST);
                i--;
            }
            Assert.AreEqual(0, stacks.CommunityDeckSize);
        }

        [TestMethod]
        public void TestChanceDeckSizeIncreasesAfterReset()
        {
            TestEmptyDeckOfChanceCards();
            stacks.ResetDeckOfCards(ChanceDeck, 5, Location.CHANCE);
            Assert.AreEqual(16, stacks.ChanceDeckSize);
        }

        [TestMethod]
        public void TestCommunityDeckSizeIncreasesAfterReset()
        {
            TestEmptyDeckOfCommunityCards();
            stacks.ResetDeckOfCards(CommunityDeck, 5, Location.COMMUNITY_CHEST);
            Assert.AreEqual(15, stacks.CommunityDeckSize);
        }

        [TestMethod]
        public void TestChanceDeckIsNotEmptyAfterReset()
        {
            var oldTopCard = ChanceDeck.Peek();
            TestChanceDeckSizeIncreasesAfterReset();
            Assert.AreEqual(oldTopCard, ChanceDeck.Peek());

        }

        [TestMethod]
        public void TestCommunityDeckIsNotEmptyAfterReset()
        {
            var oldTopCard = CommunityDeck.Peek();
            TestCommunityDeckSizeIncreasesAfterReset();
            Assert.AreEqual(oldTopCard, CommunityDeck.Peek());

        }

    }
}
