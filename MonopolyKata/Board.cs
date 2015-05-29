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
            gameBoard.Add(NewItem("Go", null, 200, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Mediterranean Avenue", "Brown", 60, "Available", "Property", null, 2));
            gameBoard.Add(NewItem("Community Chest", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Baltic Avenue", "Brown", 60, "Available", "Property", null, 4));
            gameBoard.Add(NewItem("Income Tax", null, -200, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Reading Railroad", null, 200, "Available", "Railroad", null, 25));
            gameBoard.Add(NewItem("Oriental Avenue", "Light Blue", 100, "Available", "Property", null, 6));
            gameBoard.Add(NewItem("Chance", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Vermont Avenue", "Light Blue", 100, "Available", "Property", null, 6));
            gameBoard.Add(NewItem("Connecticut Avenue", "Light Blue", 120, "Available", "Property", null, 8));
            gameBoard.Add(NewItem("Jail", null, -200, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("St. Charles Place", "Pink", 140, "Available", "Property", null, 10));
            gameBoard.Add(NewItem("Electric Company", null, 150, "Available", "Utility", null, 4));
            gameBoard.Add(NewItem("States Avenue", "Pink", 140, "Available", "Property", null, 10));
            gameBoard.Add(NewItem("Virginia Avenue", "Pink", 160, "Available", "Property", null, 12));
            gameBoard.Add(NewItem("Pennsylvania Railroad", null, 200, "Available", "Railroad", null, 25));
            gameBoard.Add(NewItem("St. James Place", "Orange", 180, "Available", "Property", null, 14));
            gameBoard.Add(NewItem("Community Chest", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Tennessee Avenue", "Orange", 180, "Available", "Property", null, 14));
            gameBoard.Add(NewItem("New York Avenue", "Orange", 200, "Available", "Property", null, 16));
            gameBoard.Add(NewItem("Free Parking", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Kentucky Avenue", "Red", 220, "Available", "Property", null, 18));
            gameBoard.Add(NewItem("Chance", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Indiana Avenue", "Red", 220, "Available", "Property", null, 18));
            gameBoard.Add(NewItem("Illinois Avenue", "Red", 240, "Available", "Property", null, 20));
            gameBoard.Add(NewItem("B&0 Railroad", null, 200, "Available", "Railroad", null, 25));
            gameBoard.Add(NewItem("Atlantic Avenue", "Yellow", 260, "Available", "Property", null, 22));
            gameBoard.Add(NewItem("Ventnor Avenue", "Yellow", 260, "Available", "Property", null, 22));
            gameBoard.Add(NewItem("Water Works", null, 150, "Available", "Utility", null, 4));
            gameBoard.Add(NewItem("Marvin Gardens", "Yellow", 280, "Available", "Property", null, 22));
            gameBoard.Add(NewItem("Go To Jail", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Pacific Avenue", "Green", 300, "Available", "Property", null, 26));
            gameBoard.Add(NewItem("North Carolina Avenue", "Green", 300, "Available", "Property", null, 26));
            gameBoard.Add(NewItem("Community Chest", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Pennsylvania Avenue", "Green", 320, "Available", "Property", null, 28));
            gameBoard.Add(NewItem("Short Line", null, 200, "Available", "Railroad", null, 25));
            gameBoard.Add(NewItem("Chance", null, 0, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Park Place", "Blue", 350, "Available", "Property", null, 35));
            gameBoard.Add(NewItem("Luxury Tax", null, -75, "Locked", "Special", null, 0));
            gameBoard.Add(NewItem("Boardwalk", "Blue", 400, "Available", "Property", null, 50));
            gameBoard.Add(NewItem("Just Visiting", null, 0, "Locked", "Special", null, 0));
        }

        public BoardSlot NewItem(String name, String color, Int32 amount, String status, String type, String ownerName, Int32 initialRent)
        {
            return new BoardSlot(name, color, amount, status, type, ownerName, initialRent);
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

        public String GetOwnerName(Int32 location)
        {
            return gameBoard[location].ownerName;
        }

        public void SetOwnerName(Int32 location, String propertyStatus)
        {
            gameBoard[location].status = propertyStatus;
        }



    }
}