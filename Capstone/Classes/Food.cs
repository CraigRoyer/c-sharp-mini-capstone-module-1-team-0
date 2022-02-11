using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Food
    {
        public string Name { get; }
        public decimal Cost { get; set; }
        public string Location { get; }
        public int snacksLeft;
        public int SnacksLeft { get; }
        public Food(string location, string name, decimal cost)
        {
            this.Location = location;
            this.Name = name;
            this.Cost = cost;
            this.SnacksLeft = 5;
        }
        public virtual void PrintMessage() { }

    }
}
