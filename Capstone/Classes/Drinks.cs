using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.VendingMachine
{
    public class Drinks : Food
    {
        public override void PrintMessage()
        {

        }
        public Drinks(string location, string name, decimal cost) : base(location, name, cost) { }
    }
}
