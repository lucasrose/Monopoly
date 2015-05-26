using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Player
    {
        public Int32 currentLocation;

        public Int32 rollOrder {get; set;}
        public Player()
        {
            currentLocation = 0;
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
