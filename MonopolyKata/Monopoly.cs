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
                    var MoneyTransfer = 0;
                    //roll dice
                    order[j].RollDicePair(gameBoard);
                    var currentLocation = order[j].currentLocation;
                    order[j].BasicAccountTransfers(currentLocation, gameBoard);
                    //buy properties
                    switch(gameBoard.GetStatus(currentLocation)){
                        case "UNAVAILABLE":
                            if (gameBoard.GetOwnerName(currentLocation) != order[j].ToString()){
                                // determine who does own it
                                var owner = DetermineOwnerOfLocation(currentLocation);
                                //its type
                                var type = gameBoard.GetType(currentLocation);
                                var multiplier = CalculateMultipleGroupMultiplier(owner, currentLocation);
                                DetermineRentOwed(type, multiplier);
                                //how much rent is owed ^^

                                //determine who owns it, and how many of the same ones they have
                                //check property type
                                
                                order[j].OwedRent(gameBoard);
                            }
                            break;
                        case "AVAILABLE":
                            order[j].PurchaseProperties(currentLocation, gameBoard);
                            gameBoard.SetOwnerName(currentLocation, order[j].ToString());
                            break;
                        case "LOCKED": //means its some special spot in the game
                            //do something
                            break;
                        
                    }
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

        private Int32 CalculateMultipleGroupMultiplier(String owner, Int32 currentLocation)
        {
            var multiplier = 1;
            var count = 0;
            var person = stringToPlayer[owner];
            switch (gameBoard.GetType(currentLocation))
            {
                case "Property":
                    var color = gameBoard.GetColor(currentLocation);
                    foreach (String element in person.ownedProperties)
                    {
                        if (person.propertyColor[element] == color)
                            count++;
                        //is a part of the same color group
                    }
                    if (count == 2 && color == "Blue" || color == "Pink")
                        multiplier = 2;
                    else if (count == 3 && color != "Blue" && color != "Pink" && color != null)
                        multiplier = 3;
                    
                    //check if all properties(colors) owned by the person counter
                    break;
                case "Utility":
                    //check if both utilities are owned
                    break;
                case "Railroad":
                    //count how many railroads are owned
                    break;
                case "Special":
                    break;
            }

            return 0;
        }

        private String DetermineOwnerOfLocation(Int32 currentLocation)
        {
           return gameBoard.GetOwnerName(currentLocation);
        }

        private Int32 DetermineRentOwed(String type, Int32 multiplier)
        {
            
            switch (type)
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