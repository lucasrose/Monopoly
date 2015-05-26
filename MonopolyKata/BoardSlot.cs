using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class BoardSlot
    {
        public Int32 amount { get; set; }
        public String name { get; set; }
        public String color { get; set; }

        public BoardSlot()
        {
            amount = 0;
            name = null;
            color = null;
        }
    }
}
