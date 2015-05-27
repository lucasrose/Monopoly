using System;


namespace MonopolyKata
{
    public class Player
    {
        public Int32 currentLocation { get; set; }
        public Int32 accountBalance { get; set; }
        public Board gameBoard = new Board();

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

        public void AdjustAccountFunds(Int32 location)
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
 
        private void SetNewLocation(Int32 value)
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

                if (currentLocation > 40)
                    accountBalance += 200;

                currentLocation = value - count;
            }
            AdjustAccountFunds(currentLocation);
        }

        public Int32 RollDicePair()
        {
            Random dice = new Random();
            var tempV = dice.Next(1, 6) + dice.Next(1, 6);
            SetNewLocation(tempV);
            return tempV;
        }
    }
}
