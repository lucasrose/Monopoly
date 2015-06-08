using System;
using System.Collections.Generic;

namespace MonopolyKata
{

    public class Board                                                                                                                      //Total Usage For Class: 2 Objects/Instances | Total Calls To Other Classes: 9
    {                                                                                                                                       //1 List
        private List<BoardSlot> gameBoard = new List<BoardSlot>();                                                                          //1 GameBoardSlot
        
        public Board()
        {
            SetupBoard();
        }

        private void SetupBoard()
        {                                                                                                                                   //Total Usage For Method: 6/2 Objects/Instances | Total Calls To Other Classes: 0
            
            gameBoard.Add(NewItem(Location.GO, Color.NULL, 200, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));                               //5 Enumms
            gameBoard.Add(NewItem(Location.MEDITERRANEAN_AVENUE, Color.BROWN, 60, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 2));         //1 Gameboard
            gameBoard.Add(NewItem(Location.COMMUNITY_CHEST, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.BALTIC_AVENUE, Color.BROWN, 60, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 4));
            gameBoard.Add(NewItem(Location.INCOME_TAX, Color.NULL, -200, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.READING_RAILROAD, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));          //5
            gameBoard.Add(NewItem(Location.ORIENTAL_AVENUE, Color.LIGHT_BLUE, 100, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 6));
            gameBoard.Add(NewItem(Location.CHANCE, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.VERMONT_AVENUE, Color.LIGHT_BLUE, 100, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 6));
            gameBoard.Add(NewItem(Location.CONNECTICUT_AVENUE, Color.LIGHT_BLUE, 120, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 8));
            gameBoard.Add(NewItem(Location.JAIL, Color.NULL, -200, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));                         //10
            gameBoard.Add(NewItem(Location.ST_CHARLES_PLACE, Color.PINK, 140, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 10));
            gameBoard.Add(NewItem(Location.ELECTRIC_COMPANY, Color.NULL, 150, Status.AVAILABLE, Type.UTILITY, Owner.NULL, 4));
            gameBoard.Add(NewItem(Location.STATES_AVENUE, Color.PINK, 140, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 10));
            gameBoard.Add(NewItem(Location.VIRGINIA_AVENUE, Color.PINK, 160, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 12));
            gameBoard.Add(NewItem(Location.PENNSYLVANIA_RAILROAD, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));   //15
            gameBoard.Add(NewItem(Location.ST_JAMES_PLACE, Color.ORANGE, 180, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 14));
            gameBoard.Add(NewItem(Location.COMMUNITY_CHEST, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.TENNESSEE_AVENUE, Color.ORANGE, 180, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 14));
            gameBoard.Add(NewItem(Location.NEW_YORK_AVENUE, Color.ORANGE, 200, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 16));
            gameBoard.Add(NewItem(Location.FREE_PARKING, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));                   //20
            gameBoard.Add(NewItem(Location.KENTUCKY_AVENUE, Color.RED, 220, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 18));
            gameBoard.Add(NewItem(Location.KENTUCKY_AVENUE, Color.RED, 220, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 18));
            gameBoard.Add(NewItem(Location.CHANCE, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.INDIANA_AVENUE, Color.RED, 220, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 18));
            gameBoard.Add(NewItem(Location.ILLINOIS_AVENUE, Color.RED, 240, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 20));          //25
            gameBoard.Add(NewItem(Location.BO_RAILROAD, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));
            gameBoard.Add(NewItem(Location.ATLANTIC_AVENUE, Color.YELLOW, 260, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 22));
            gameBoard.Add(NewItem(Location.VENTNOR_AVENUE, Color.YELLOW, 260, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 22));
            gameBoard.Add(NewItem(Location.WATER_WORKS, Color.NULL, 150, Status.AVAILABLE, Type.UTILITY, Owner.NULL, 4));
            gameBoard.Add(NewItem(Location.MARVIN_GARDENS, Color.YELLOW, 280, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 22));        //30
            gameBoard.Add(NewItem(Location.GO_TO_JAIL, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.NORTH_CAROLINA_AVENUE, Color.GREEN, 300, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 26));
            gameBoard.Add(NewItem(Location.COMMUNITY_CHEST, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.PENNSYLVANIA_AVENUE, Color.GREEN, 320, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 28));
            gameBoard.Add(NewItem(Location.SHORT_LINE, Color.NULL, 200, Status.AVAILABLE, Type.RAILROAD, Owner.NULL, 25));              //35
            gameBoard.Add(NewItem(Location.CHANCE, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.PARK_PLACE, Color.BLUE, 350, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 35));
            gameBoard.Add(NewItem(Location.LUXURY_TAX, Color.NULL, -75, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));
            gameBoard.Add(NewItem(Location.BOARDWALK, Color.BLUE, 400, Status.AVAILABLE, Type.PROPERTY, Owner.NULL, 50));
            gameBoard.Add(NewItem(Location.JUST_VISITING, Color.NULL, 0, Status.LOCKED, Type.SPECIAL, Owner.NULL, 0));               //40

        }

        public BoardSlot NewItem(Location location, Color color, Int32 amount, Status status, Type type, Owner owner, Int32 rent)           //Total Usage For Method: 6/2 Objects/Instances | Total Calls To Other Classes: 0    
        {                                                                                                                                   //5 Enums
            return new BoardSlot(location, color, amount, status, type, owner, rent);                                                       //1 BoardSlot
        }

        public Location GetLocation(Int32 location)                                                                                         //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9                                                                              
        {                                                                                                                                   //1 Enum
            return gameBoard[location].Location;                                                                                            //1 GameBoard
        }

        public Color GetColor(Int32 location)                                                                                               //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {                                                                                                                                   //1 Enum
            return gameBoard[location].Color;                                                                                               //1 GameBoard
        }

        public Int32 GetAmount(Int32 location)                                                                                              //Total Usage For Method: 1/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {
            return gameBoard[location].Amount;                                                                                              //1 GameBoard
        }

        public Status GetStatus(Int32 location)                                                                                             //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {                                                                                                                                   //1 Enum
            return gameBoard[location].Status;                                                                                              //1 GameBoard
        }

        public Type GetType(Int32 location)                                                                                                 //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {                                                                                                                                   //1 Enum
            return gameBoard[location].Type;                                                                                                //1 GameBoard
        }

        public Owner GetOwner(Int32 location)                                                                                               //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {                                                                                                                                   //1 Enum
            return gameBoard[location].Owner;                                                                                               //1 GameBoard
        }

        public Int32 GetRent(Int32 location)                                                                                                //Total Usage For Method: 1/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {
            return gameBoard[location].Rent;                                                                                                //1 GameBoard
        }

        public void SetOwnerName(Int32 location, Owner propertyStatus)                                                                      //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {                                                                                                                                   //1 Enum
            gameBoard[location].Owner = propertyStatus;                                                                                     //1 GameBoard
        }

        public void SetStatus(Int32 location, Status propertyStatus)                                                                        //Total Usage For Method: 2/2 Objects/Instances | Total Calls To Other Classes: 1/9
        {                                                                                                                                   //1 Enum
            gameBoard[location].Status = propertyStatus;                                                                                    //1 GameBoard
        }

    }
}