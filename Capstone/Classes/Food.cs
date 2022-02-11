using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Food
    {
        static int startingSnacks = 5;
        public string Name { get; }
        public decimal Cost { get; set; }
        public string Location { get; }
        public int snacksLeft;
        public int SnacksLeft { get; set; }
        public Food(string location, string name, decimal cost)
        {
            this.Location = location;
            this.Name = name;
            this.Cost = cost;
            this.SnacksLeft = startingSnacks;
        }
        public virtual void PrintMessage() { }

    }
}
