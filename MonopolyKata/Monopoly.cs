using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public class Monopoly
    {
        public Dictionary<Int32, Player> Order = new Dictionary<Int32, Player>();
        public Dictionary<String, Player> StringToPlayer = new Dictionary<String, Player>();
        public Board GameBoard = new Board();
        private Player player1 = new Player();
        private Player player2 = new Player();
        private Player player3 = new Player();
        private Player player4 = new Player();
        private Int32[] rollOrder = { 0, 0, 0, 0 };

        public Monopoly()
        {
            DetermineOrder();
            DistinctOrder();
            StringToPlayer.Add("player1", player1);
            StringToPlayer.Add("player2", player2);
            StringToPlayer.Add("player3", player3);
            StringToPlayer.Add("player4", player4);

            Order.Add(rollOrder[0], player1);
            Order.Add(rollOrder[1], player2);
            Order.Add(rollOrder[2], player3);
            Order.Add(rollOrder[3], player4);
            RunMonopoly(20);
        }

        public Player GetPlayer(Int32 number)
        {
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

        public Int32 DistinctOrder()
        {
            return (rollOrder[0] + rollOrder[1] + rollOrder[2] + rollOrder[3]);
        }

        private void DetermineOrder()
        {
            Random order = new Random();
            rollOrder[0] = order.Next(1, 4);
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

        public void RunMonopoly(Int32 maxNumberOfRounds)
        {
            var currentNumberOfRounds = 0;
            while (currentNumberOfRounds < maxNumberOfRounds)
            {
                var playerNumber = 1;
                while (playerNumber < 5)
                {
                    Order[playerNumber].RollDicePair(GameBoard);
                    var currentLocation = Order[playerNumber].CurrentLocation;
                    Order[playerNumber].BasicAccountTransfers(currentLocation, GameBoard);
                    switch (GameBoard.GetStatus(currentLocation))
                    {
                        case "UNAVAILABLE":
                            if (GameBoard.GetOwnerName(currentLocation) != Order[playerNumber].ToString())
                            {
                                var owner = DetermineOwnerOfLocation(currentLocation);
                                var type = GameBoard.GetType(currentLocation);
                                var multiplier = CalculateMultipleGroupMultiplier(owner, currentLocation);
                                var ownerOfProperty = StringToPlayer[owner];
                                var rentOwed = GameBoard.GetInitialRent(currentLocation) * multiplier;

                                Order[playerNumber].AccountBalance -= rentOwed;
                                ownerOfProperty.AccountBalance += rentOwed;
                            }
                            break;
                        case "AVAILABLE":
                            Order[playerNumber].PurchaseProperties(currentLocation, GameBoard);
                            GameBoard.SetOwnerName(currentLocation, Order[playerNumber].ToString());
                            break;
                        case "LOCKED":
                            //do something
                            break;
                    }
                    playerNumber++;
                }
                currentNumberOfRounds++;
            }
        }

        private Int32 CalculateMultipleGroupMultiplier(String owner, Int32 currentLocation)
        {
            var multiplier = 1;
            var count = 0;
            var person = StringToPlayer[owner];
            var type = GameBoard.GetType(currentLocation);
            var color = GameBoard.GetColor(currentLocation);
            switch (GameBoard.GetType(currentLocation))
            {
                case "Property":
                    foreach (String element in person.OwnedProperties)
                        if (person.PropertyColor[element] == color)
                            count++;
                    if (count == 2 && color == "Blue" || color == "Pink")
                        multiplier = 2;
                    else if (count == 3 && color != "Blue" && color != "Pink" && color != null)
                        multiplier = 3;
                    break;
                case "Utility":

                    foreach (String element in person.OwnedProperties)
                        if (person.TypeOfProperty[element] == type)
                            count++;
                    if (count == 2)
                        multiplier = 10 / 4;
                    break;
                case "Railroad":
                    foreach (String element in person.OwnedProperties)
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
                case "Special":
                    break;
            }
            return multiplier;
        }

        private String DetermineOwnerOfLocation(Int32 currentLocation)
        {
            return GameBoard.GetOwnerName(currentLocation);
        }

    }


    //Land in Jail
        //draw go to jail
        //land on go to jail
        //throws doubles three times in a row
}