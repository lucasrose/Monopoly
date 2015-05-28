using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public class Player
    {
        public Int32 currentLocation {get; set;}
        public Int32 accountBalance {get; set;}

        public List <String> ownedProperties = new List<String>();
        public List<String> mortgagedProperties = new List<String>();

        private Int32 currentDiceRoll = 0;

        public Int32 rollOrder {get; set;}
        public Player()
        {
            currentLocation = 0;
            accountBalance = 0;
        }
        public Int32 GetAccountBalance()
        {
            return accountBalance;
        }

        public void BasicAccountTransfers(Int32 location, Board gameBoard)
        {
            switch (gameBoard.GetName(location))
            {
                case "Go":
                    accountBalance += 200;
                    break;
                case "Go To Jail":
                    currentLocation = 41;
                    break;
                case "Income Tax":
                    if (accountBalance * (.20) > 200)
                        accountBalance -= 200;
                    else
                        accountBalance -= (Int32)(accountBalance * (.20));
                    break;
                case "Luxury Tax":
                    accountBalance -= 75;
                    break;
                default:
                    break;
            }
        }

        public Int32 GetCurrentLocation()
        {
            return currentLocation;
        } 
 
        private void SetNewLocation(Int32 value, Board gameBoard)
        {
            if ((currentLocation + value) <= 40)
            {
                currentLocation += value;
            }
            else
            {
                var count = 0;
                while (currentLocation <= 40)
                {
                    currentLocation += value;
                    count++;
                }
                //manage passing go
                if (currentLocation > 40)
                    accountBalance += 200;

                currentLocation = value - count;
            }
            //BasicAccountTransfers(currentLocation, gameBoard);
            //PurchaseProperties(currentLocation, gameBoard);
        }

        public void PurchaseProperties(Int32 currentLocation, Board gameBoard)
        {
            var property = gameBoard.GetName(currentLocation);

            switch (gameBoard.GetStatus(currentLocation))
            {
                case "AVAILABLE":
                    ownedProperties.Add(property);
                    ChargeAccount(currentLocation, gameBoard);
                    gameBoard.SetStatus(currentLocation, "UNAVAILABLE");
                    break;
                case "UNAVAILABLE":
                    OwedRent(gameBoard);
                    break;
                case "LOCKED":
                    //do other
                    break;
            }

        }

        private void ChargeAccount(int currentLocation, Board gameBoard)
        {
            var price = gameBoard.GetAmount(currentLocation);
            accountBalance -= price;
        }

        public Int32 OwedRent(Board gameBoard)
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
            //check all properties in color group
            //properties (all properties of color group, rent doubles)
            //one utility, rent = 4* value on dice, 2 utilities, rent = 10 * value on dice
            //railroads 1 railroad 25, 2 railroads 50, 3 - 100, 4, 200
        }

        public Int32 TransferMoney(Int32 currentLocation)
        {
            return 0;
        }
   

        public Int32 RollDicePair(Board gameBoard)
        {
            Random dice = new Random();
            var tempV = dice.Next(1, 6) + dice.Next(1, 6);
            currentDiceRoll = tempV;
            SetNewLocation(tempV, gameBoard);
            return tempV;
        }

    }
}
