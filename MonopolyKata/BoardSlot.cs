using System;

namespace MonopolyKata
{
    public enum Location
    {
        GO, MEDITERRANEAN_AVENUE, COMMUNITY_CHEST, BALTIC_AVENUE,
        INCOME_TAX, READING_RAILROAD, ORIENTAL_AVENUE, CHANCE, VERMONT_AVENUE, CONNECTICUT_AVENUE,
        JAIL, ST_CHARLES_PLACE, ELECTRIC_COMPANY, STATES_AVENUE, VIRGINIA_AVENUE, PENNSYLVANIA_RAILROAD,
        ST_JAMES_PLACE, TENNESSEE_AVENUE, NEW_YORK_AVENUE, FREE_PARKING, KENTUCKY_AVENUE,
        INDIANA_AVENUE, ILLINOIS_AVENUE, BO_RAILROAD, ATLANTIC_AVENUE, VENTNOR_AVENUE, WATER_WORKS,
        MARVIN_GARDENS, GO_TO_JAIL, PACIFIC_AVENUE, NORTH_CAROLINA_AVENUE,
        PENNSYLVANIA_AVENUE, SHORT_LINE, PARK_PLACE, LUXURY_TAX, BOARDWALK, JUST_VISITING
    };

    public enum Color { BROWN, LIGHT_BLUE, PINK, ORANGE, RED, YELLOW, GREEN, BLUE, NULL };

    public enum Status { UNAVAILABLE, AVAILABLE, LOCKED };

    public enum Type { PROPERTY, UTILITY, RAILROAD, SPECIAL };

    public enum Owner { PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR, NULL };

    public class BoardSlot
    {

        public Location Location{get; set;}
        public Color Color {get; set;}
        public Int32 Amount {get; set;}
        public Status Status {get; set;}
        public Type Type {get; set;}
        public Owner Owner {get; set;}
        public Int32 Rent {get; set;}



        public BoardSlot(Location Location, Color Color, Int32 Amount, Status Status, Type Type, Owner Owner, Int32 Rent)
        {
            Location = new Location();
            Color = new Color();
            this.Amount = Amount;
            Status = new Status();
            Type = new Type();
            Owner = new Owner();
            this.Rent = Rent;
        }



       /*ublic Int32 Amount;
        public String Name;
        public String Color;
        public String Status;
        public String Type;
        public String OwnerName;
        public Int32 InitialRent;
        */
        /*public BoardSlot(String name, String color, Int32 amount, String status, String type, String ownerName, Int32 initialRent)
        {
            this.Name = name;
            this.Amount = amount;
            this.Color = color;
            this.Status = status;
            this.Type = type;
            this.OwnerName = ownerName;
            this.InitialRent = initialRent;
        }*/
    }
}