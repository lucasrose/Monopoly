using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public class Monopoly
    {
        private Player player1 = new Player();
        private Player player2 = new Player();
        private Player player3 = new Player();
        private Player player4 = new Player();
        public Dictionary<Int32, Player> order = new Dictionary<Int32, Player>();
        public Dictionary<String, Player> stringToPlayer = new Dictionary<String, Player>();
        public Board gameBoard = new Board();

        private Int32[] RollOrder = { 0, 0, 0, 0 };

        public Monopoly()
        {
            DetermineOrder();
            DistinctOrder();
            stringToPlayer.Add("player1", player1);
            stringToPlayer.Add("player2", player2);
            stringToPlayer.Add("player3", player3);
            stringToPlayer.Add("player4", player4);

            order.Add(RollOrder[0], player1);
            order.Add(RollOrder[1], player2);
            order.Add(RollOrder[2], player3);
            order.Add(RollOrder[3], player4);
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
            return (RollOrder[0] + RollOrder[1] + RollOrder[2] + RollOrder[3]);
        }

        private void DetermineOrder()
        {
            Random order = new Random();
            RollOrder[0] = order.Next(1, 4);
            RollOrder[1] = order.Next(1, 4);
            while (RollOrder[1] == RollOrder[0])
                RollOrder[1] = order.Next(1, 4);

            RollOrder[2] = order.Next(1, 4);
            while (RollOrder[2] == RollOrder[1] || RollOrder[2] == RollOrder[0])
                RollOrder[2] = order.Next(1, 4);

            var tempValue = (RollOrder[0] + RollOrder[1] + RollOrder[2]);
            switch (tempValue)
            {
                case 6:
                    RollOrder[3] = 4;
                    break;
                case 8:
                    RollOrder[3] = 2;
                    break;
                case 9:
                    RollOrder[3] = 1;
                    break;
                default:
                    RollOrder[3] = 3;
                    break;
            }
        }

        public void RunMonopoly(Int32 numberOfRounds)
        {
            var i = 0;
            while (i < numberOfRounds)
            {
                var j = 1;
                while (j < 5)
                {
                    //var MoneyTransfer = 0;
                    //roll dice
                    order[j].RollDicePair(gameBoard);
                    var currentLocation = order[j].currentLocation;
                    order[j].BasicAccountTransfers(currentLocation, gameBoard);
                    //buy properties
                    switch (gameBoard.GetStatus(currentLocation))
                    {
                        case "UNAVAILABLE":
                            if (gameBoard.GetOwnerName(currentLocation) != order[j].ToString())
                            {
                                var owner = DetermineOwnerOfLocation(currentLocation);
                                var type = gameBoard.GetType(currentLocation);
                                var multiplier = CalculateMultipleGroupMultiplier(owner, currentLocation);
                                var ownerOfProperty = stringToPlayer[owner];
                                var rentOwed = gameBoard.GetInitialRent(currentLocation) * multiplier;

                                order[j].accountBalance -= rentOwed;
                                ownerOfProperty.accountBalance += rentOwed;
                            }
                            break;
                        case "AVAILABLE":
                            order[j].PurchaseProperties(currentLocation, gameBoard);
                            gameBoard.SetOwnerName(currentLocation, order[j].ToString());
                            break;
                        case "LOCKED":
                            //do something
                            break;

                    }
                    j++;
                }

                i++;
            }
        }

        private Int32 CalculateMultipleGroupMultiplier(String owner, Int32 currentLocation)
        {
            var multiplier = 1;
            var count = 0;
            var person = stringToPlayer[owner];
            var type = gameBoard.GetType(currentLocation);
            var color = gameBoard.GetColor(currentLocation);

            switch (gameBoard.GetType(currentLocation))
            {
                case "Property":
                    foreach (String element in person.ownedProperties)
                    {
                        if (person.propertyColor[element] == color)
                            count++;
                    }
                    if (count == 2 && color == "Blue" || color == "Pink")
                        multiplier = 2;
                    else if (count == 3 && color != "Blue" && color != "Pink" && color != null)
                        multiplier = 3;
                    break;
                case "Utility":

                    foreach (String element in person.ownedProperties)
                        if (person.typeOfProperty[element] == type)
                            count++;
                    if (count == 2)
                        multiplier = 10 / 4;
                    break;
                case "Railroad":
                    foreach (String element in person.ownedProperties)
                        if (person.typeOfProperty[element] == type)
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
            return gameBoard.GetOwnerName(currentLocation);
        }

    }
}