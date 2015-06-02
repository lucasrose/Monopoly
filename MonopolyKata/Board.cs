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

       /* private void SetupBoard()
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
        }*/

        private void SetupBoard() {

            gameBoard.Add(NewItem(Location.GO, Color.NULL, 200, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.MEDITERRANEAN_AVENUE, Color.BROWN, 60, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 2));
            gameBoard.Add(NewItem(Location.COMMUNITY_CHEST, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.BALTIC_AVENUE, Color.BROWN, 60, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 4));
            gameBoard.Add(NewItem(Location.INCOME_TAX, Color.NULL, -200, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.READING_RAILROAD, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));
            gameBoard.Add(NewItem(Location.ORIENTAL_AVENUE, Color.LIGHT_BLUE, 100, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 6));
            gameBoard.Add(NewItem(Location.CHANCE, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.VERMONT_AVENUE, Color.LIGHT_BLUE, 100, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 6));
            gameBoard.Add(NewItem(Location.CONNECTICUT_AVENUE, Color.LIGHT_BLUE, 120, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 8));
            gameBoard.Add(NewItem(Location.JAIL, Color.NULL, -200, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.ST_CHARLES_PLACE, Color.PINK, 140, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 10));
            gameBoard.Add(NewItem(Location.ELECTRIC_COMPANY, Color.NULL, 150, Status.AVAILABLE, Type.UTILITY, Owner.NULL, 4));
            gameBoard.Add(NewItem(Location.STATES_AVENUE, Color.PINK, 140, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 10));
            gameBoard.Add(NewItem(Location.VIRGINIA_AVENUE, Color.PINK, 160, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 12));
            gameBoard.Add(NewItem(Location.PENNSYLVANIA_RAILROAD, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));
            gameBoard.Add(NewItem(Location.ST_JAMES_PLACE, Color.ORANGE, 180, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 14));
            gameBoard.Add(NewItem(Location.COMMUNITY_CHEST, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.TENNESSEE_AVENUE, Color.ORANGE, 180, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 14));
            gameBoard.Add(NewItem(Location.NEW_YORK_AVENUE, Color.ORANGE, 200, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 16));
            gameBoard.Add(NewItem(Location.FREE_PARKING, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.KENTUCKY_AVENUE, Color.RED, 220, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 18));
            gameBoard.Add(NewItem(Location.KENTUCKY_AVENUE, Color.RED, 220, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 18));
            gameBoard.Add(NewItem(Location.CHANCE, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.INDIANA_AVENUE, Color.RED, 220, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 18));
            gameBoard.Add(NewItem(Location.ILLINOIS_AVENUE, Color.RED, 240, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 20));
            gameBoard.Add(NewItem(Location.BO_RAILROAD, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));
            gameBoard.Add(NewItem(Location.ATLANTIC_AVENUE, Color.YELLOW, 260, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 22));
            gameBoard.Add(NewItem(Location.VENTNOR_AVENUE, Color.YELLOW, 260, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 22));
            gameBoard.Add(NewItem(Location.WATER_WORKS, Color.NULL, 150, Status.AVAILABLE, Type.UTILITY, Owner.NULL, 4));
            gameBoard.Add(NewItem(Location.MARVIN_GARDENS, Color.YELLOW, 280, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 22));
            gameBoard.Add(NewItem(Location.GO_TO_JAIL, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.NORTH_CAROLINA_AVENUE, Color.GREEN, 300, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 26));
            gameBoard.Add(NewItem(Location.COMMUNITY_CHEST, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.PENNSYLVANIA_AVENUE, Color.GREEN, 320, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 28));
            gameBoard.Add(NewItem(Location.SHORT_LINE, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));
            gameBoard.Add(NewItem(Location.CHANCE, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.PARK_PLACE, Color.BLUE, 350, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 35));
            gameBoard.Add(NewItem(Location.LUXURY_TAX, Color.NULL, -75, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.BOARDWALK, Color.BLUE, 400, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 50));
            gameBoard.Add(NewItem(Location.JUST_VISITING, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));

        }   

        public BoardSlot NewItem(Location location, Color color, Int32 amount, Status status, Type type, Owner owner, Int32 rent)
        {
            return new BoardSlot(location, color, amount, status, type, owner, rent);
        }

        public Location GetLocation(Int32 location)
        {
            return gameBoard[location].Location;
        }

        public Color GetColor(Int32 location)
        {
            return gameBoard[location].Color;
        }

        public Int32 GetAmount(Int32 location)
        {
            return gameBoard[location].Amount;
        }

        public Status GetStatus(Int32 location)
        {
            return gameBoard[location].Status;
        }

        public Type GetType(Int32 location)
        {
            return gameBoard[location].Type;
        }

        public Owner GetOwner(Int32 location)
        {
            return gameBoard[location].Owner;
        }

        public Int32 GetRent(Int32 location)
        {
            return gameBoard[location].Rent;
        }

        public void SetOwnerName(Int32 location, Owner propertyStatus)
        {
            gameBoard[location].Owner = propertyStatus;
        }

        public void SetStatus(Int32 location, Status propertyStatus)
        {
            gameBoard[location].Status = propertyStatus;
        }
        /*public BoardSlot NewItem(String name, String color, Int32 amount, String status, String type, String ownerName, Int32 initialRent)
        {
            return new BoardSlot(name, color, amount, status, type, ownerName, initialRent);
        }
        public String GetName(Int32 location)
        {
            return gameBoard[location].Name;
        }

        public String GetColor(Int32 location)
        {
            return gameBoard[location].Color;
        }

        public Int32 GetAmount(Int32 location)
        {
            return gameBoard[location].Amount;
        }

        public String GetType(Int32 location)
        {
            return gameBoard[location].Type;
        }
        public String GetStatus(Int32 location)
        {
            return gameBoard[location].Status;
        }

        public void SetStatus(Int32 location, String propertyStatus)
        {
            gameBoard[location].Status = propertyStatus;
        }

        public String GetOwnerName(Int32 location)
        {
            return gameBoard[location].OwnerName;
        }

        public void SetOwnerName(Int32 location, String propertyStatus)
        {
            gameBoard[location].Status = propertyStatus;
        }

        public Int32 GetInitialRent(Int32 location)
        {
            return gameBoard[location].InitialRent;
        }*/



    }
}