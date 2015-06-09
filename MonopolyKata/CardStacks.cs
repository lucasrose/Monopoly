using System;
using System.Collections.Generic;

namespace MonopolyKata
{

    public enum Cards
    {
        ADVANCE_TO_GO /* in both */, ADVANCE_TO_ILLINOIS, ADVANCE_TO_ST_CHARLES, ADVANCE_TO_UTILITY, ADVANCE_TO_RAILROAD,
        BANK_PAYS_DIVIDEND, GET_OUT_OF_JAIL_FREE /* in both */, GO_BACK_3_SPACES, GO_TO_JAIL /* in both */, MAKE_REPAIRS, PAY_POOR_TAX,
        GO_TO_READING_RAILROAD, TAKE_A_WALK_BOARDWALK, CHAIRMAN_OF_BOARD, LOAN_MATURES, WON_CROSSWORD,

        DOCTORS_FEES, SELL_STOCK, GRAND_OPERA, HOLIDAY_FUND_MATURES,
        INCOME_TAX_REFUND, YOUR_BIRTHDAY, LIFE_INSURANCE_MATURES, PAY_HOSPITAL_FEES, PAY_SCHOOL_FEES,
        STREET_REPAIRS, SECOND_PRIZE_BEAUTY, INHERIT_MONEY
    }

    public class CardStacks
    {
        public List<Cards> NewChanceCards;
        public List<Cards> NewCommunityCards;
        public Int32 ChanceDeckSize { get; private set; }
        public Int32 CommunityDeckSize { get; private set; }
        public Stack<Cards> ChanceDeck = new Stack<Cards>();
        public Stack<Cards> CommunityDeck = new Stack<Cards>();

        public CardStacks()
        {
            PopulateListOfCards();
            ChanceDeckSize = 16;
            CommunityDeckSize = 15;
            ShuffleOfCards(NewChanceCards, 5);
            ShuffleOfCards(NewCommunityCards, 5);
            StraightenUpDeckOfCards(ChanceDeck, NewChanceCards);
            StraightenUpDeckOfCards(CommunityDeck, NewCommunityCards);
        }

        public void PopulateListOfCards()
        {
            NewChanceCards = new List<Cards>{Cards.ADVANCE_TO_GO, Cards.ADVANCE_TO_ILLINOIS, Cards.ADVANCE_TO_ST_CHARLES, 
                 Cards.ADVANCE_TO_UTILITY, Cards.ADVANCE_TO_RAILROAD, Cards.BANK_PAYS_DIVIDEND, Cards.GET_OUT_OF_JAIL_FREE, 
                 Cards.GO_BACK_3_SPACES, Cards.GO_TO_JAIL, Cards.MAKE_REPAIRS, Cards.PAY_POOR_TAX, Cards.GO_TO_READING_RAILROAD, 
                 Cards.TAKE_A_WALK_BOARDWALK, Cards.CHAIRMAN_OF_BOARD, Cards.LOAN_MATURES, Cards.WON_CROSSWORD};

            NewCommunityCards = new List<Cards>{Cards.ADVANCE_TO_GO, Cards.DOCTORS_FEES, Cards.SELL_STOCK, Cards.GRAND_OPERA, 
                Cards.GET_OUT_OF_JAIL_FREE, Cards.HOLIDAY_FUND_MATURES, Cards.INCOME_TAX_REFUND, Cards.YOUR_BIRTHDAY, 
                Cards.LIFE_INSURANCE_MATURES, Cards.PAY_HOSPITAL_FEES, Cards.GO_TO_JAIL, Cards.PAY_SCHOOL_FEES, Cards.STREET_REPAIRS, 
                Cards.SECOND_PRIZE_BEAUTY, Cards.INHERIT_MONEY};
        }

        public void ShuffleOfCards(List<Cards> deckOfCards, Int32 numberOfTimesToShuffle)
        {
            Random random = new Random();
            int x = deckOfCards.Count;
            while (numberOfTimesToShuffle != 0)
            {
                while (x > 1)
                {
                    x--;
                    int newRand = random.Next(x + 1);
                    Cards tempCard = deckOfCards[newRand];
                    deckOfCards[newRand] = deckOfCards[x];
                    deckOfCards[x] = tempCard;
                }
                numberOfTimesToShuffle--;
            }
        }

        public void StraightenUpDeckOfCards(Stack<Cards> deckOfCards, List<Cards> items)
        {
            foreach (Cards card in items)
                deckOfCards.Push(card);
        }

        public Cards TakeCardOffStack(Stack<Cards> deckOfCards, Location location)
        {
            var card = deckOfCards.Pop();
            if (location == Location.CHANCE)
                ChanceDeckSize--;
            else if (location == Location.COMMUNITY_CHEST)
                CommunityDeckSize--;
            return card;
        }

        public void ResetDeckOfCards(Stack<Cards> deckOfCards, Int32 numberOfTimesToShuffle, Location location)
        {
            if (location == Location.CHANCE)
            {
                ChanceDeckSize = 16;
                StraightenUpDeckOfCards(deckOfCards, NewChanceCards);
            }
            else if (location == Location.COMMUNITY_CHEST)
            {
                CommunityDeckSize = 15;
                StraightenUpDeckOfCards(deckOfCards, NewCommunityCards);
            }
        }

    }
}
