using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Board
    {
        private List<BoardSlot> gameBoard = new List<BoardSlot>();

        public Board()
        {
            SetupBoard();
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
            gameBoard.Add(new BoardSlot("Community Chest", null, 0));
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
            gameBoard.Add(new BoardSlot("Just Visiting", null, 0));

        }

        public String GetName(Int32 location)
        {
            return gameBoard[location].name;
        }

        public String GetColor(Int32 location)
        {
            return gameBoard[location].color;
        }

        public Int32 GetAmount(Int32 location)
        {
            return gameBoard[location].amount;
        }

    }
}
