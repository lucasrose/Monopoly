using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace MonopolyKata
{
    public class Monopoly
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Player player3 = new Player();
        Player player4 = new Player();
        public Dictionary<Int32, Player> order = new Dictionary<Int32, Player>();
        Int32[] RollOrder = { 0, 0, 0, 0 };
        private List<BoardSlot> gameBoard = new List<BoardSlot>();
        
        public BoardSlot getObjectFromBoard(Int32 location){
            return gameBoard[location];
        }
        
        

        public Monopoly()
        {
            SetupBoard();
            DetermineOrder();
            DistinctOrder();
            order.Add(RollOrder[0], player1);
            order.Add(RollOrder[1], player2);
            order.Add(RollOrder[2], player3);
            order.Add(RollOrder[3], player4);
        }

        private void SetupBoard()
        {
            gameBoard.Add(new BoardSlot("Go", null, 200));
            gameBoard.Add(new BoardSlot("Mediterranean Avenue", "Brown", 60));
            gameBoard.Add(new BoardSlot("Community Chest", null, 0));
            gameBoard.Add(new BoardSlot("Baltic Avenue", "Brown", 60));
            gameBoard.Add(new BoardSlot("Income Tax", null, -200));
            gameBoard.Add(new BoardSlot("Reading Railroad", null, 200));
            gameBoard.Add(new BoardSlot("Oriental Avenue", "Light Blue", 100));
            gameBoard.Add(new BoardSlot("Chance", null, 0));
            gameBoard.Add(new BoardSlot("Vermont Avenue", "Light Blue", 100));
            gameBoard.Add(new BoardSlot("Connecticut Avenue", "Light Blue", 120));
            gameBoard.Add(new BoardSlot("Jail", null, -200));
            gameBoard.Add(new BoardSlot("St. Charles Place", "Pink", 140));
            gameBoard.Add(new BoardSlot("Electric Company", null, 150));
            gameBoard.Add(new BoardSlot("States Avenue", "Pink", 140));
            gameBoard.Add(new BoardSlot("Virginia Avenue", "Pink", 160));
            gameBoard.Add(new BoardSlot("Pennsylvania Railroad", null, 200));
            gameBoard.Add(new BoardSlot("St. James Place", "Orange", 180));
            gameBoard.Add(new BoardSlot("Tennessee Avenue", "Orange", 180));
            gameBoard.Add(new BoardSlot("New York Avenue", "Orange", 200));
            gameBoard.Add(new BoardSlot("Free Parking", null, 0));
            gameBoard.Add(new BoardSlot("Kentucky Avenue", "Red", 220));
            gameBoard.Add(new BoardSlot("Chance", null, 0));
            gameBoard.Add(new BoardSlot("Indiana Avenue", "Red", 220));
            gameBoard.Add(new BoardSlot("Illinois Avenue", "Red", 240));
            gameBoard.Add(new BoardSlot("B&0 Railroad", null, 200));
            gameBoard.Add(new BoardSlot("Atlantic Avenue", "Yellow", 260));
            gameBoard.Add(new BoardSlot("Ventnor Avenue", "Yellow", 260));
            gameBoard.Add(new BoardSlot("Water Works", null, 150));
            gameBoard.Add(new BoardSlot("Marvin Gardens", "Yellow", 280));
            gameBoard.Add(new BoardSlot("Go To Jail", null, 0));
            gameBoard.Add(new BoardSlot("Pacific Avenue", "Green", 300));
            gameBoard.Add(new BoardSlot("North Carolina Avenue", "Green", 300));
            gameBoard.Add(new BoardSlot("Community Chest", null, 0));
            gameBoard.Add(new BoardSlot("Pennsylvania Avenue", "Green", 320));
            gameBoard.Add(new BoardSlot("Short Line", null, 200));
            gameBoard.Add(new BoardSlot("Chance", null, 0));
            gameBoard.Add(new BoardSlot("Park Place", "Blue", 350));
            gameBoard.Add(new BoardSlot("Luxury Tax", null, -75));
            gameBoard.Add(new BoardSlot("Boardwalk", "Blue", 400));

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

            if (tempValue == 6)
                RollOrder[3] = 4;
            else if (tempValue == 8)
                RollOrder[3] = 2;
            else if (tempValue == 9)
                RollOrder[3] = 1;
            else
                RollOrder[3] = 3;
        }
       
    }
}
