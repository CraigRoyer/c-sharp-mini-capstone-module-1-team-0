using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Food
    {
        public string Name { get; }
        public decimal Cost { get; }
        public string Location { get; }
        public Food(string location, string name, decimal cost)
        {
            this.Location = location;
            this.Name = name;
            this.Cost = cost;
        }
        public abstract void PrintMessage();

    }
}
