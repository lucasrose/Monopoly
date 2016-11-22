using System;

namespace MonopolyKata
{
    public class BoardSlot
    {
        public Int32 amount;
        public String name;
        public String color;
        public String status;
        public String type;
        public String ownerName;
        public Int32 initialRent;
        public BoardSlot(String name, String color, Int32 amount, String status, String type, String ownerName, Int32 initialRent)
        {
            this.name = name;
            this.amount = amount;
            this.color = color;
            this.status = status;
            this.type = type;
            this.ownerName = ownerName;
            this.initialRent = initialRent;
        }

    }
}