using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public enum PlayerStatus{FREE, JAILED};
    public class Player                                                                                             //Total Usage For Class: 8 Objects/Instances | Total Calls To Other Classes: 7
    {
        public Int32 CurrentLocation {get; set;}
        public Int32 AccountBalance {get; set;}
        public Int32 RollOrder {get; set;}
        public Int32 NumberOfRoundsInJail;
        public List<Location> OwnedProperties = new List<Location>();                                               //1 List, 1 Enum
        public Dictionary<Location, Color> PropertyColor = new Dictionary<Location, Color>();                       //1 Dictionary, 1 Enum
        public Dictionary<Location, Type> TypeOfProperty = new Dictionary<Location, Type>();                        //1 Dictionary, 1 Enum
        public PlayerStatus PlayerStatus {get; set;}
        public List<String> MortgagedProperties = new List<String>();                                               //1 List, 1 String
        private Int32 currentDiceRoll = 0;

        public Player()
        {
            CurrentLocation = 0;
            AccountBalance = 0;
            NumberOfRoundsInJail = 0;
            PlayerStatus = PlayerStatus.FREE;
        }

        public Int32 GetAccountBalance()                                                                            //Total Usage For Method: 0/8 Objects/Instances | Total Calls To Other Classes: 0/7
        {
            return AccountBalance;
        }

        public void BasicAccountTransfers(Int32 location, Board gameBoard)                                          //Total Usage For Method: 2/8 Objects/Instances | Total Calls To Other Classes: 1/7
        {
            switch (gameBoard.GetLocation(location))                                                                //1 GameBoard
            {
                case Location.GO:                                                                                   //1 Enum
                    AccountBalance += 200;
                    break;
                case Location.GO_TO_JAIL:
                    CurrentLocation = 10;
                    PlayerStatus = PlayerStatus.JAILED;
                    break;
                case Location.INCOME_TAX:
                    if (AccountBalance * (.20) > 200)
                        AccountBalance -= 200;
                    else
                        AccountBalance -= (Int32)(AccountBalance * (.20));
                    break;
                case Location.LUXURY_TAX:
                    AccountBalance -= 75;
                    break;
                default:
                    break;
            }
        }

        public Int32 GetCurrentLocation()                                                                           //Total Usage For Method: 0/8 Objects/Instances | Total Calls To Other Classes: 0/7
        {
            return CurrentLocation;
        }

        private void SetNewLocation(Int32 value, Board gameBoard)                                                   //Total Usage For Method: 1/8 Objects/Instances | Total Calls To Other Classes: 0/7
        {
            if ((CurrentLocation + value) <= 40)
            {
                CurrentLocation += value;
            }
            else
            {
                var count = 0;
                while (CurrentLocation <= 40)
                {
                    CurrentLocation += value;
                    count++;
                }
                if (CurrentLocation > 40)
                    AccountBalance += 200;

                CurrentLocation = value - count;
            }
        }

        public void PurchaseProperties(Int32 currentLocation, Board gameBoard)                                      //Total Usage For Method: 5/8 Objects/Instances | Total Calls To Other Classes: 4/7
        {
            var property = gameBoard.GetLocation(currentLocation);                                                  //1 GameBoard
            var color = gameBoard.GetColor(currentLocation);
            var type = gameBoard.GetType(currentLocation);
            OwnedProperties.Add(property);                                                                          //3 Dictionaries
            PropertyColor.Add(property, color);
            TypeOfProperty.Add(property, type);
            ChargeAccount(currentLocation, gameBoard);
            gameBoard.SetStatus(currentLocation, Status.UNAVAILABLE);                                               //1 Enum
        }

        private void ChargeAccount(int currentLocation, Board gameBoard)                                            //Total Usage For Method: 1/8 Objects/Instances | Total Calls To Other Classes: 1/7
        {
            var price = gameBoard.GetAmount(currentLocation);                                                       //1 GameBoard
            AccountBalance -= price;
        }

        public Int32 RollDicePair(Board gameBoard)                                                                  //Total Usage For Method: 2/8 Objects/Instances | Total Calls To Other Classes: 1/7
        {                                                                                                           //1 GameBoard
            Random dice = new Random();                                                                             //1 Random
            
            var numDoubles = 0;
            var dice1 = dice.Next(1, 6);
            var dice2 = dice.Next(1, 6);
            var tempV = dice1 + dice2;
            currentDiceRoll = tempV;
            

            if (PlayerStatus.JAILED == PlayerStatus)
            {
                //they roll, if not doubles, increment count and dont move
                if (dice1 != dice2 && NumberOfRoundsInJail < 3)
                {
                    NumberOfRoundsInJail++;
                }
                else
                {
                    NumberOfRoundsInJail = 0;
                    PlayerStatus = PlayerStatus.FREE;
                    SetNewLocation(currentDiceRoll, gameBoard);
                }
                //if double, reset count and move to that location
            }
            else
            {
                //do what i already did
                while (dice1 == dice2)
                {
                    if (numDoubles == 3)
                    {
                        BasicAccountTransfers(31, gameBoard);
                        break;
                    }
                    numDoubles++;

                    dice1 = dice.Next(1, 6);
                    dice2 = dice.Next(1, 6);
                    tempV = dice1 + dice2;
                    currentDiceRoll += tempV;
                }
                SetNewLocation(currentDiceRoll, gameBoard);
            }
            return currentDiceRoll;
        }

    }
}
