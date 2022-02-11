using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Food
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
        public Gum(string location, string name, decimal cost) : base(location, name, cost) { }
    }
}
