﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Food
    {
        public override void PrintMessage()
        {
            Console.WriteLine("thing");
        }
        public Chip(string location, string name, decimal cost) : base(location, name, cost) { }
        
    }
}
