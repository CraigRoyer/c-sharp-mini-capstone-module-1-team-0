using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.VendingMachine
{
    public class Gum : Food
    {
        public override void PrintMessage()
        {
            
        }
        public Gum(string location, string name, decimal cost) : base(location, name, cost) { }
    }
}
