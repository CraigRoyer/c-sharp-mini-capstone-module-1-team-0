using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class LogSheet
    {
        public void Audit(string food)
        {

        }

        public void Audit(decimal money)
        {

        }
        public bool AdjustBalance(decimal change)
        {

            // if you adjust the balance and the amount is NOT negative it will change the Balance

            if ((balance += change) >= 0)
            {
                // also going to LOG cash inserted here.
                balance += change;
                return true;
            }
            // else if money inserted is not a positive INT
            else
            {
                Console.WriteLine("Invalid balance amount.");
                return false;
            }
        }

        public void GiveChange()
        {
        }



        static decimal balance;


        public void PrintSalesReport()
        {

        }
    }
}
