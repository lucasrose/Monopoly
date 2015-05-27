using System;

namespace MonopolyKata
{
    public class BoardSlot
    {
        public Int32 amount;
        public String name;
        public String color;

        public BoardSlot(String name, String color, Int32 amount)
        {
            this.name = name;
            this.amount = amount;
            this.color = color;
        }
    }
}
