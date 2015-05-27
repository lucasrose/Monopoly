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
        private Int32[] RollOrder = { 0, 0, 0, 0 };
        
        public Monopoly()
        {
            DetermineOrder();
            DistinctOrder();
            order.Add(RollOrder[0], player1);
            order.Add(RollOrder[1], player2);
            order.Add(RollOrder[2], player3);
            order.Add(RollOrder[3], player4);
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
            {
                RollOrder[1] = order.Next(1, 4);
            }

            RollOrder[2] = order.Next(1, 4);
            while (RollOrder[2] == RollOrder[1] || RollOrder[2] == RollOrder[0])
            {
                RollOrder[2] = order.Next(1, 4);
            }

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
    }
}
