using System;

namespace MonopolyKata
{
    public class BoardSlot
    {
        public Int32 amount;
        public String name;
        public String color;
        public String status;

        public BoardSlot(String name, String color, Int32 amount, String status)
        {
            this.name = name;
            this.amount = amount;
            this.color = color;
            this.status = status;
        }

    }
}