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
            gameBoard.Add(new BoardSlot("Go", null, 200, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Mediterranean Avenue", "Brown", 60, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Community Chest", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Baltic Avenue", "Brown", 60, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Income Tax", null, -200, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Reading Railroad", null, 200, "Available", "Railroad"));
            gameBoard.Add(new BoardSlot("Oriental Avenue", "Light Blue", 100, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Chance", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Vermont Avenue", "Light Blue", 100, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Connecticut Avenue", "Light Blue", 120, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Jail", null, -200, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("St. Charles Place", "Pink", 140, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Electric Company", null, 150, "Available", "Utility"));
            gameBoard.Add(new BoardSlot("States Avenue", "Pink", 140, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Virginia Avenue", "Pink", 160, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Pennsylvania Railroad", null, 200, "Available", "Railroad"));
            gameBoard.Add(new BoardSlot("St. James Place", "Orange", 180, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Community Chest", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Tennessee Avenue", "Orange", 180, "Available", "Property"));
            gameBoard.Add(new BoardSlot("New York Avenue", "Orange", 200, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Free Parking", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Kentucky Avenue", "Red", 220, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Chance", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Indiana Avenue", "Red", 220, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Illinois Avenue", "Red", 240, "Available", "Property"));
            gameBoard.Add(new BoardSlot("B&0 Railroad", null, 200, "Available", "Railroad"));
            gameBoard.Add(new BoardSlot("Atlantic Avenue", "Yellow", 260, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Ventnor Avenue", "Yellow", 260, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Water Works", null, 150, "Available", "Utility"));
            gameBoard.Add(new BoardSlot("Marvin Gardens", "Yellow", 280, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Go To Jail", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Pacific Avenue", "Green", 300, "Available", "Property"));
            gameBoard.Add(new BoardSlot("North Carolina Avenue", "Green", 300, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Community Chest", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Pennsylvania Avenue", "Green", 320, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Short Line", null, 200, "Available", "Railroad"));
            gameBoard.Add(new BoardSlot("Chance", null, 0, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Park Place", "Blue", 350, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Luxury Tax", null, -75, "Locked", "Special"));
            gameBoard.Add(new BoardSlot("Boardwalk", "Blue", 400, "Available", "Property"));
            gameBoard.Add(new BoardSlot("Just Visiting", null, 0, "Locked", "Special"));
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

        public String GetType(Int32 location)
        {
            return gameBoard[location].type;
        }
        public String GetStatus(Int32 location)
        {
            return gameBoard[location].status;
        }

        public void SetStatus(Int32 location, String propertyStatus)
        {
            gameBoard[location].status = propertyStatus;
        }
    }
}