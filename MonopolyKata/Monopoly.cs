using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public class Monopoly                                                                                               //Total Usage for Class: 9 Objects/Instances created | Total Calls To Other Classes: 18
    {                                                                                                                   //Breakdown:
        public Dictionary<Int32, Player> Order = new Dictionary<Int32, Player>();                                       //3 Dictionaries
        public Dictionary<Owner, Player> OwnerToPlayer = new Dictionary<Owner, Player>();
        public Dictionary<Player, Owner> PlayerToOwner = new Dictionary<Player, Owner>();
        public CardStacks CardStacks = new CardStacks();
        public Board GameBoard = new Board();                                                                           //1 Gameboard
        private Player player1 = new Player();                                                                          //4 Players
        private Player player2 = new Player();
        private Player player3 = new Player();
        private Player player4 = new Player();
        private Int32[] rollOrder = { 0, 0, 0, 0 };                                                                   //1 Int Array

        public Monopoly()
        {
            DetermineOrder();
            DistinctOrder();
            SetUpPlayers();
            RunMonopoly(20);
        }

        private void SetUpPlayers()
        {
            OwnerToPlayer.Add(Owner.PLAYER_ONE, player1);
            OwnerToPlayer.Add(Owner.PLAYER_TWO, player2);
            OwnerToPlayer.Add(Owner.PLAYER_THREE, player3);
            OwnerToPlayer.Add(Owner.PLAYER_FOUR, player4);

            PlayerToOwner.Add(player1, Owner.PLAYER_ONE);
            PlayerToOwner.Add(player2, Owner.PLAYER_TWO);
            PlayerToOwner.Add(player3, Owner.PLAYER_THREE);
            PlayerToOwner.Add(player4, Owner.PLAYER_FOUR);

            Order.Add(rollOrder[0], player1);
            Order.Add(rollOrder[1], player2);
            Order.Add(rollOrder[2], player3);
            Order.Add(rollOrder[3], player4);
        }

        public Player GetPlayer(Int32 number)                                                                           //Total Usage for Method: 4/9 Objects/Instances | Total Calls To Other Classes: 0/18
        {                                                                                                               //4/4 Players
            switch (number)
            {
                case 1:
                    return player1;
                case 2:
                    return player2;
                case 3:
                    return player3;
                case 4:
                    return player4;
                default:
                    return null;

            }
        }

        public Int32 DistinctOrder()                                                                                    //Total Usage For Method: 1/9 Objects/Instances | Total Calls To Other Classes: 0/18
        {
            return (rollOrder[0] + rollOrder[1] + rollOrder[2] + rollOrder[3]);
        }

        private void DetermineOrder()                                                                                   //Total Usage For Method: 2/9 Objects/Instances | Total Calls To Other Classes: 1/18
        {
            Random order = new Random();                                                                                //1 Random
            rollOrder[0] = order.Next(1, 4);                                                                            //1 Int array
            rollOrder[1] = order.Next(1, 4);
            while (rollOrder[1] == rollOrder[0])
                rollOrder[1] = order.Next(1, 4);

            rollOrder[2] = order.Next(1, 4);
            while (rollOrder[2] == rollOrder[1] || rollOrder[2] == rollOrder[0])
                rollOrder[2] = order.Next(1, 4);

            var tempValue = (rollOrder[0] + rollOrder[1] + rollOrder[2]);
            switch (tempValue)
            {
                case 6:
                    rollOrder[3] = 4;
                    break;
                case 8:
                    rollOrder[3] = 2;
                    break;
                case 9:
                    rollOrder[3] = 1;
                    break;
                default:
                    rollOrder[3] = 3;
                    break;
            }
        }

        public void RunMonopoly(Int32 maxNumberOfRounds)                                                                //Total Usage For Method: 9/9 Objects/Instances | Total Calls To Other Classes: 11/18                                   
        {
            MonopolyLogic(maxNumberOfRounds);
        }

        private void MonopolyLogic(Int32 maxNumberOfRounds)
        {
            var currentNumberOfRounds = 0;
            while (currentNumberOfRounds < maxNumberOfRounds)
            {
                var playerNumber = 1;
                while (playerNumber < 5)                                                                                //4 Players
                {
                    Order[playerNumber].RollDicePair(GameBoard);                                                        //1 Dictionary
                    var currentLocation = Order[playerNumber].CurrentLocation;
                    var loc = GameBoard.GetLocation(currentLocation);
                    BuyOrPayRent(playerNumber, currentLocation);
                    Order[playerNumber].BasicAccountTransfers(currentLocation, GameBoard);
                   

                    playerNumber++;
                }
                currentNumberOfRounds++;
            }
        }

        private void BuyOrPayRent(Int32 playerNumber, Int32 currentLocation)
        {
            switch (GameBoard.GetStatus(currentLocation))                                                       //1 GameBoard
            {
                case Status.UNAVAILABLE:                                                                        //3 Enums
                    if (OwnerToPlayer[GameBoard.GetOwner(currentLocation)] != Order[playerNumber])
                    {
                        var owner = GameBoard.GetOwner(currentLocation);
                        var type = GameBoard.GetType(currentLocation);
                        var multiplier = CalculateMultipleGroupMultiplier(owner, currentLocation);
                        var ownerOfProperty = OwnerToPlayer[owner];
                        var rentOwed = GameBoard.GetRent(currentLocation) * multiplier;

                        Order[playerNumber].AccountBalance -= rentOwed;
                        ownerOfProperty.AccountBalance += rentOwed;
                    }
                    break;

                case Status.AVAILABLE:
                    Order[playerNumber].PurchaseProperties(currentLocation, GameBoard);
                    var player = Order[playerNumber];
                    GameBoard.SetOwnerName(currentLocation, PlayerToOwner[player]);
                    break;

                case Status.LOCKED:
                    var loc = GameBoard.GetLocation(currentLocation);
                    ChanceAndCommunityCardActions(playerNumber, loc);
                    if (loc == Location.GO_TO_JAIL)
                    {
                        Order[playerNumber].PlayerStatus = PlayerStatus.JAILED;
                        Order[playerNumber].CurrentLocation = 10;
                    }
                    break;

            }
        }

        private void ChanceAndCommunityCardActions(Int32 playerNumber, Location loc)
        {

            var player = Order[playerNumber];
            var currLoc = player.CurrentLocation;

            if (loc == Location.CHANCE)
            {
                if (CardStacks.ChanceDeckSize == 0)
                {
                    CardStacks.ResetDeckOfCards(CardStacks.ChanceDeck, 5, Location.CHANCE);
                }
                var chanceCard = CardStacks.TakeCardOffStack(CardStacks.ChanceDeck, loc);

                switch (chanceCard)
                {
                    case Cards.GET_OUT_OF_JAIL_FREE:
                        player.NumberOfGetOutOfJailFreeCards++;
                        break;

                    case Cards.ADVANCE_TO_GO:
                        player.CurrentLocation = 0;
                        player.BasicAccountTransfers(0, GameBoard);
                        break;

                    case Cards.ADVANCE_TO_ILLINOIS:
                        if (currLoc >= 25)
                            player.AccountBalance += 200;
                        currLoc = 25;
                        break;

                    case Cards.ADVANCE_TO_ST_CHARLES:
                        if (currLoc >= 11)
                            player.AccountBalance += 200;
                        currLoc = 11;
                        break;

                    case Cards.ADVANCE_TO_UTILITY:
                        if (currLoc >= 12 && currLoc < 29)
                            currLoc = 29;
                        else
                            currLoc = 12;

                        BuyOrPayRent(playerNumber, currLoc);
                        break;

                    case Cards.ADVANCE_TO_RAILROAD:
                        if (currLoc >= 5 && currLoc < 15)
                            currLoc = 15;
                        else if (currLoc >= 15 && currLoc < 26)
                            currLoc = 26;
                        else if (currLoc >= 26 && currLoc < 35)
                            currLoc = 35;
                        else
                            currLoc = 5;

                        BuyOrPayRent(playerNumber, currLoc);

                        break;

                    case Cards.BANK_PAYS_DIVIDEND:
                        Order[playerNumber].AccountBalance += 50;

                        break;

                    case Cards.GO_BACK_3_SPACES:
                        if (currLoc > 2)
                            currLoc -= 3;
                        else if (currLoc == 2)
                            currLoc = 39;
                        else if (currLoc == 1)
                            currLoc = 38;
                        else
                            currLoc = 37;

                        break;

                    case Cards.GO_TO_JAIL:  ///
                        currLoc = 31;
                        player.BasicAccountTransfers(currLoc, GameBoard);
                        break;

                    case Cards.MAKE_REPAIRS:
                        player.AccountBalance -= 25 * player.OwnedProperties.Count;
                        break;

                    case Cards.PAY_POOR_TAX:
                        player.AccountBalance -= 15;
                        break;

                    case Cards.GO_TO_READING_RAILROAD:
                        if (currLoc >= 5)
                            player.AccountBalance += 200;
                        currLoc = 5;
                        break;

                    case Cards.TAKE_A_WALK_BOARDWALK:
                        player.CurrentLocation = 39;
                        break;

                    case Cards.CHAIRMAN_OF_BOARD:
                        for (var i = 0; i < 5; i++)
                        {
                            if (Order[i] != player)
                            {
                                Order[i].AccountBalance += 50;
                                player.AccountBalance -= 50;
                            }
                        }
                        break;

                    case Cards.LOAN_MATURES:
                        player.AccountBalance += 150;
                        break;

                    case Cards.WON_CROSSWORD:
                        player.AccountBalance += 100;
                        break;

                }
            }
            else if (loc == Location.COMMUNITY_CHEST)
            {
                if (CardStacks.CommunityDeckSize == 0)
                    CardStacks.ResetDeckOfCards(CardStacks.CommunityDeck, 5, Location.COMMUNITY_CHEST);

                var communityDeck = CardStacks.CommunityDeck;
                var commCard = CardStacks.TakeCardOffStack(communityDeck, loc);
                switch (commCard)
                {
                    case Cards.GET_OUT_OF_JAIL_FREE:
                        player.NumberOfGetOutOfJailFreeCards++;
                        break;

                    case Cards.DOCTORS_FEES:
                        player.AccountBalance -= 50;
                        break;

                    case Cards.SELL_STOCK:
                        player.AccountBalance += 50;
                        break;

                    case Cards.GRAND_OPERA:
                        for (var i = 0; i < 5; i++)
                        {
                            if (Order[i] != player)
                            {
                                Order[i].AccountBalance -= 50;
                                player.AccountBalance += 50;
                            }
                        }
                        break;

                    case Cards.HOLIDAY_FUND_MATURES:
                        player.AccountBalance += 100;
                        break;

                    case Cards.INCOME_TAX_REFUND:
                        player.AccountBalance += 20;
                        break;

                    case Cards.YOUR_BIRTHDAY:
                        for (var i = 0; i < 5; i++)
                        {
                            if (Order[i] != player)
                            {
                                Order[i].AccountBalance -= 10;
                                player.AccountBalance += 10;
                            }
                        }
                        break;

                    case Cards.LIFE_INSURANCE_MATURES:
                        player.AccountBalance += 100;
                        break;

                    case Cards.PAY_HOSPITAL_FEES:
                        player.AccountBalance -= 100;
                        break;

                    case Cards.PAY_SCHOOL_FEES:
                        player.AccountBalance -= 150;
                        break;

                    case Cards.STREET_REPAIRS:
                        player.AccountBalance += player.OwnedProperties.Count * 40;
                        break;

                    case Cards.SECOND_PRIZE_BEAUTY:
                        player.AccountBalance += 10;
                        break;

                    case Cards.INHERIT_MONEY:
                        player.AccountBalance += 100;
                        break;

                    case Cards.ADVANCE_TO_GO:
                        player.AccountBalance += 00;
                        break;

                    case Cards.GO_TO_JAIL:///
                        player.CurrentLocation = 0;
                        player.BasicAccountTransfers(0, GameBoard);
                        break;
                }

            }
        }

        private Int32 CalculateMultipleGroupMultiplier(Owner owner, Int32 currentLocation)                          //Total Usage For Method: 9/9 Objects/Instances | Total Calls To Other Classes: 6/18
        {                                                                                                           //5 Enums
            var multiplier = 1;
            var count = 0;
            var person = OwnerToPlayer[owner];                                                                      //1 Dictionary
            var type = GameBoard.GetType(currentLocation);                                                          //1 GameBoard
            var color = GameBoard.GetColor(currentLocation);
            switch (GameBoard.GetType(currentLocation))
            {
                case Type.PROPERTY:
                    foreach (Location element in person.OwnedProperties)
                        if (person.PropertyColor[element] == color)                                                 //1 Dictionary
                            count++;
                    if (count == 2 && color == Color.BLUE || color == Color.PINK)
                        multiplier = 2;
                    else if (count == 3 && color != Color.BLUE && color != Color.PINK && color != Color.NULL)
                        multiplier = 3;
                    break;
                case Type.UTILITY:

                    foreach (Location element in person.OwnedProperties)
                        if (person.TypeOfProperty[element] == type)                                                 //1 Dictionary
                            count++;
                    if (count == 2)
                        multiplier = 10 / 4;
                    break;
                case Type.RAILROAD:
                    foreach (Location element in person.OwnedProperties)
                        if (person.TypeOfProperty[element] == type)
                            count++;
                    switch (count)
                    {
                        case 2:
                            multiplier = 2;
                            break;
                        case 3:
                            multiplier = 4;
                            break;
                        case 4:
                            multiplier = 8;
                            break;
                    }
                    break;
                case Type.SPECIAL:
                    break;
            }
            return multiplier;
        }


    }
}