using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group03
{
    class Room
    {
        public string Type;
        public int Quantity;
        public double Price;

        public Room(string type, int quantity, double price)
        {
            Type = type;
            Quantity = quantity;
            Price = price;
        }
    }
}
