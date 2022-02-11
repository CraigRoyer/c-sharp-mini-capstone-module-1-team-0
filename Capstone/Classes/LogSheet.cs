using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace Capstone.Classes
{
    public class LogSheet
    {
        public LogSheet()
        {
            balance = 0;

        }
        public void Audit(Food foodItem)
        {
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string fullPath = Path.Combine(directory, file);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} {foodItem.Name} {this.Balance.ToString("C")} {(this.Balance - foodItem.Cost).ToString("C")}"); //left off here
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
            }
        }

        public void Audit(decimal money) 
        {
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string fullPath = Path.Combine(directory, file);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} FEED MONEY: {this.Balance.ToString("C")} {(this.Balance + money).ToString("C")}"); //left off here
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
            }
            //tracks money inserted


        }

        //public decimal ChangeOwed { get; set; } i dont think we need this anymore thanks DAVID
        public bool AdjustBalance(decimal change) 
        {

            // if you adjust the balance and the amount is NOT negative it will change the Balance
            if (change == 1 || change == 2 || change == 5 || change == 10)
            {
     
                
                    this.Audit(change);// also going to LOG cash inserted here.
                    balance += change;
                    Console.WriteLine($"Current Balance is: {balance.ToString("C")}");
                    return true;
                
            }
            // else if money inserted is not a positive INT
            
                Console.WriteLine("Invalid dollar amount. We only accept WHOLE DOLLAR$");
                return false;
            
        }
        public bool AdjustBalance(Food foodItem) 
        {

            // if you adjust the balance and the amount is NOT negative it will change the Balance

            if ((balance - foodItem.Cost) >= 0)
            {
                this.Audit(foodItem);// going to LOG food purchased here.
                balance -= foodItem.Cost;
                Console.WriteLine($"Current Balance is: {balance.ToString("C")}");
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
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string fullPath = Path.Combine(directory, file);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} GIVE CHANGE: {Balance.ToString("C")} $0.00"); //left off here
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
            }
        
        Console.WriteLine($"Your change is: {balance.ToString("C")}");

            while (balance >= 0.25M)
            {
                balance -= 0.25M;
                Console.WriteLine("Here's a quarter");
                Thread.Sleep(800);
                Console.Clear();
                Console.WriteLine("CLINK");
                Thread.Sleep(500);
                Console.Clear();
            }
            while (balance >= 0.10M)
            {
                balance -= 0.10M;
                Console.WriteLine("Here's a dime");
                Thread.Sleep(800);
                Console.Clear();
                Console.WriteLine("cLiNk");
                Thread.Sleep(500);
                Console.Clear();
            }
            while (balance >= 0.05M)
            {
                balance -= 0.05M;
                Console.WriteLine("Here's a nickel");
                Thread.Sleep(800);
                Console.Clear();
                Console.WriteLine("clink");
                Thread.Sleep(500);
                Console.Clear();
            }


        }



        static decimal balance;
        public decimal Balance 
        { 
            get
                
            { return balance; }
        }


        public void PrintSalesReport()
        {

        }
    }
}
