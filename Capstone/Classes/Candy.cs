using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : Food
    {
        public override void PrintMessage()
        {

        }
        public Candy(string location, string name, decimal cost) : base(location, name, cost) { }
    }
}
