using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class LogSheet
    {

        public LogSheet()
        {
            Balance = 0;
        }



        public void Audit(string food)
        {

        }

        public void Audit(decimal money)
        {

        }

        public bool AdjustBalance(decimal change)
        {
           
            // if you adjust the balance and the amount is NOT negative it will change the Balance

            if((Balance += change) >= 0)
            {
                // also going to LOG cash inserted here.
                Balance += change;
                return true;
            }
            // else if money inserted is not a positive INT
            else 
            {
                Console.WriteLine("Invalid balance amount.");
                return false;
            }
        }

        static decimal Balance;

        public void PrintSalesReport()
        {

        }
    }
}
