﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.VendingMachine
{
    public class Chips : Food
    {
        public override void PrintMessage()
        {

        }
        public Chips(string location, string name, decimal cost) : base(location, name, cost) { }
    }
}
