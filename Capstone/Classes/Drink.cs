using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Food
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
        public Drink(string location, string name, decimal cost) : base(location, name, cost) 
        { 
        }

        
    }
}
