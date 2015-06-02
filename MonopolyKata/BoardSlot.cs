using System;

namespace MonopolyKata
{
    public class BoardSlot
    {

        /*public Int32 rent;
        public Int32 amount;

        public enum Location
        {
            GO, MEDITERRANEAN_AVENUE, COMMUNITY_CHEST, BALTIC_AVENUE,
            INCOME_TAX, READING_RAILROAD, ORIENTAL_AVENUE, CHANCE, VERMONT_AVENUE, CONNECTICUT_AVENUE,
            JAIL, ST_CHARLES_PLACE, ELECTRIC_COMPANY, STATES_AVENUE, VIRGINIA_AVENUE, PENNSYLVANIA_RAILROAD,
            ST_JAMES_PLACE, COMMUNITY_CHEST, TENNESSEE_AVENUE, NEW_YORK_AVENUE, FREE_PARKING, KENTUCKY_AVENUE,
            INDIANA_AVENUE, ILLINOIS_AVENUE, BO_RAILROAD, ATLANTIC_AVENUE, VENTNOR_AVENUE, WATER_WORKS,
            MARVIN_GARDENS, GO_TO_JAIL, PACIFIC_AVENUE, NORTH_CAROLINA_AVENUE, COMMUNITY_CHEST,
            PENNSYLVANIA_AVENUE, SHORT_LINE, PARK_PLACE, LUXURY_TAX, BOARDWALK, JUST_VISITING
        };

        public enum Color { BROWN, LIGHT_BLUE, PINK, ORANGE, RED, YELLOW, GREEN, BLUE };

        public enum Status { UNAVAILABLE, AVAILABLE, LOCKED };

        public enum Type { PROPERTY, UTILITY, RAILROAD };

        public enum Owner { PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR };


        public BoardSlot(Location location, Color color, Int32 amount, Status status, Type type, Owner owner, Int32 rent)
        {
            location = new Location();
            color = new Color();
            this.amount = amount;
            status = new Status();
            type = new Type();
            owner = new Owner();
            this.rent = rent;
        }*/
        public Int32 Amount;
        public String Name;
        public String Color;
        public String Status;
        public String Type;
        public String OwnerName;
        public Int32 InitialRent;

        public BoardSlot(String name, String color, Int32 amount, String status, String type, String ownerName, Int32 initialRent)
        {
            this.Name = name;
            this.Amount = amount;
            this.Color = color;
            this.Status = status;
            this.Type = type;
            this.OwnerName = ownerName;
            this.InitialRent = initialRent;
        }
    }
}