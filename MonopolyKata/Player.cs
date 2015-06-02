using System;
using System.Collections.Generic;


namespace MonopolyKata
{
    public class Player
    {
        public Int32 CurrentLocation { get; set; }
        public Int32 AccountBalance { get; set; }
        public Int32 RollOrder { get; set; }
        public List<String> OwnedProperties = new List<String>();
        public Dictionary<String, String> PropertyColor = new Dictionary<String, String>();
        public Dictionary<String, String> TypeOfProperty = new Dictionary<String, String>();
        public List<String> MortgagedProperties = new List<String>();
        private Int32 currentDiceRoll = 0;

        public Player()
        {
            CurrentLocation = 0;
            AccountBalance = 0;
        }

        public Int32 GetAccountBalance()
        {
            return AccountBalance;
        }

        public void BasicAccountTransfers(Int32 location, Board gameBoard)
        {
            switch (gameBoard.GetName(location))
            {
                case "Go":
                    AccountBalance += 200;
                    break;
                case "Go To Jail":
                    CurrentLocation = 41;
                    break;
                case "Income Tax":
                    if (AccountBalance * (.20) > 200)
                        AccountBalance -= 200;
                    else
                        AccountBalance -= (Int32)(AccountBalance * (.20));
                    break;
                case "Luxury Tax":
                    AccountBalance -= 75;
                    break;
                default:
                    break;
            }
        }

        public Int32 GetCurrentLocation()
        {
            return CurrentLocation;
        }

        private void SetNewLocation(Int32 value, Board gameBoard)
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

        public void PurchaseProperties(Int32 currentLocation, Board gameBoard)
        {
            var property = gameBoard.GetName(currentLocation);
            var color = gameBoard.GetColor(currentLocation);
            var type = gameBoard.GetType(currentLocation);
            OwnedProperties.Add(property);
            PropertyColor.Add(property, color);
            TypeOfProperty.Add(property, type);
            ChargeAccount(currentLocation, gameBoard);
            gameBoard.SetStatus(currentLocation, "UNAVAILABLE");
        }

        private void ChargeAccount(int currentLocation, Board gameBoard)
        {
            var price = gameBoard.GetAmount(currentLocation);
            AccountBalance -= price;
        }

        public Int32 RollDicePair(Board gameBoard)
        {
            Random dice = new Random();
            var numDoubles = 0;
            var dice1 = dice.Next(1, 6);
            var dice2 = dice.Next(1, 6);
            if (dice1 == dice2)
                numDoubles++;

            var tempV = dice1 + dice2;
            currentDiceRoll = tempV;
            SetNewLocation(tempV, gameBoard);
            return tempV;
        }

    }
}
