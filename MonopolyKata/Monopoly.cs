using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public class Monopoly                                                                                               //Total Usage for Class: 9 Objects/Instances created | Total Calls To Other Classes: 18
    {                                                                                                                   //Breakdown:
        public Dictionary<Int32, Player> Order = new Dictionary<Int32, Player>();                                       //3 Dictionaries
        public Dictionary<Owner, Player> OwnerToPlayer = new Dictionary<Owner, Player>();                   
        public Dictionary<Player, Owner> PlayerToOwner = new Dictionary<Player, Owner>();
        public Board GameBoard = new Board();                                                                           //1 Gameboard
        private Player player1 = new Player();                                                                          //4 Players
        private Player player2 = new Player();
        private Player player3 = new Player();
        private Player player4 = new Player();
        private Int32[] rollOrder = { 0, 0, 0, 0 };                                                                     //1 Int Array

        public Monopoly()
        {
            DetermineOrder();
            DistinctOrder();
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
            RunMonopoly(20);
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
            var currentNumberOfRounds = 0;
            while (currentNumberOfRounds < maxNumberOfRounds)
            {
                var playerNumber = 1;
                while (playerNumber < 5)                                                                                //4 Players
                {
                    Order[playerNumber].RollDicePair(GameBoard);                                                        //1 Dictionary
                    var currentLocation = Order[playerNumber].CurrentLocation;
                    Order[playerNumber].BasicAccountTransfers(currentLocation, GameBoard);
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
                            //do something
                            break;
                    }
                    playerNumber++;
                }
                currentNumberOfRounds++;
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

    //Notes:
    //Land in Jail
        //draw go to jail
        //land on go to jail
        //throws doubles three times in a row
}