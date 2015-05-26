using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Player: Monopoly 
    {
        private Int32 currentLocation;
        private Int32 accountBalance;

        public Int32 rollOrder {get; set;}
        public Player()
        {
            
            currentLocation = 0;
            accountBalance = 0;
        }
        public Int32 getAccountBalance()
        {
            return accountBalance;
        }

        private void adjustAccountFunds(Int32 location)
        {
            //if this is Go, receive 200
            if (getObjectFromBoard(location).name == "Go")
            {
                accountBalance += 200;
            }
            //if passing go


            else if (getObjectFromBoard(location).name == "Go To Jail")
            {
            }
            else if (getObjectFromBoard(location).name == "Income Tax")
            {
                if (accountBalance * (.20) > 200)
                {
                    accountBalance -= 200;
                }
                else
                {
                    accountBalance -= (Int32)(accountBalance * (.20));
                }
            }
            else if (getObjectFromBoard(location).name == "Luxury Tax")
            {
                accountBalance -= 75;
            }
        }
        public Int32 getCurrentLocation()
        {
            return currentLocation;
        }
 
        private void setNewLocation(Int32 value)
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
                currentLocation = value - count;
              
            }
            adjustAccountFunds(currentLocation);

        }

        public Int32 rollDicePair()
        {
            Random dice = new Random();
            var tempV = dice.Next(1, 6) + dice.Next(1, 6);
            setNewLocation(tempV);
            return tempV;
        }

    }
}
