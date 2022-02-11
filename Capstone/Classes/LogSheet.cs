using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class LogSheet
    {
        public void Audit(Food foodItem, LogSheet)
        {
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string fullPath = Path.Combine(directory, file);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} {foodItem.Name} {foodItem.Cost}"); //left off here
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //tracking food purchased
            //adjust sales report
        }

        public void Audit(decimal money) 
        {
            //tracks money inserted
            
             
        }

        //public decimal ChangeOwed { get; set; } i dont think we need this anymore thanks DAVID
        public bool AdjustBalance(decimal change) 
        {

            // if you adjust the balance and the amount is NOT negative it will change the Balance

            if (change >= 0)
            {
                this.Audit(change);// also going to LOG cash inserted here.
                balance += change;
                Console.WriteLine($"Current Balance is: ${balance}");
                return true;
            }
            // else if money inserted is not a positive INT
            else
            {
                Console.WriteLine("Invalid dollar amount.");
                return false;
            }
        }
        public bool AdjustBalance(Food foodItem) 
        {

            // if you adjust the balance and the amount is NOT negative it will change the Balance

            if ((balance - foodItem.Cost) >= 0)
            {
                this.Audit(foodItem);// going to LOG food purchased here.
                balance -= foodItem.Cost;
                Console.WriteLine($"Current Balance is: ${balance}");
                return true;
            }
            // else user does not have sufficient funds
            else
            {
                Console.WriteLine("Insufficient Funds.");
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
