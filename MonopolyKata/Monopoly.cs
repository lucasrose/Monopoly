﻿using System;
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
        public Board gameBoard = new Board();

        private Int32[] RollOrder = { 0, 0, 0, 0 };
        
        public Monopoly()
        {
            DetermineOrder();
            DistinctOrder();
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
            while(RollOrder[1] == RollOrder[0])
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

        public void RunMonopoly(Int32 numberOfGames)
        {
            var i = 0;
            while (i < numberOfGames)
            {
                var j = 1;
                while (j < 5){
                    //roll dice
                    order[j].RollDicePair(gameBoard);
                    var currentLocation = order[j].currentLocation;
                    order[j].BasicAccountTransfers(currentLocation, gameBoard);
                    //buy properties
                    switch(gameBoard.GetStatus(currentLocation)){
                        case "UNAVAILABLE":
                            if (gameBoard.GetOwnerName(currentLocation) != order[j].ToString()){
                                //you dont own it, its taken, determine who does, its type and how much rent is owed
                                DetermineOwnerOfLocation(currentLocation);
                                //determine who owns it, and how many of the same ones they have
                                CaclulatePropertyRentOwed(currentLocation);
                                //check property type
                                
                                order[j].OwedRent(gameBoard);
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
                    //check if you dont own it and that its taken
                        //check who owns it
                        
                        

                        //create transfer of money

                    //buy or pay rent on property
                    // var rent = order[j].OwedRent(gameBoard);   //Monopoly or Player Class?
                    //check for if other players own each property
                    
                    j++;
                }

                i++;
            }
        }

        private void DetermineOwnerOfLocation(Int32 currentLocation)
        {
            throw new NotImplementedException();
        }

        private Int32 CaclulatePropertyRentOwed(Int32 currentLocation)
        {
            switch (gameBoard.GetType(currentLocation))
            {
                case "Property":
                    //check colors (all or one owned by a single person)
                    break;
                case "Utility":
                    //1 = 4*dice roll , 2 = 4*dice roll
                    //check if the one landed on the other person owns as well,
                    //if they do pay 4* dice roll
                    break;
                case "Railroad":
                    //check if player owns 1,2,3,4 properties 25, 50, 100, 200
                    break;
                case "Special":
                    break;
            }
            return 0;
        }

    }
}