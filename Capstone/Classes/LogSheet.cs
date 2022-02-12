using System;
using System.Collections.Generic;
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
        public bool Audit(Food foodItem)
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
                return true;
            }
            catch (IOException)
            {
                Console.WriteLine("The Log file was corrupted");
                return false;
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
                return false;
            }
        }

        public bool Audit(decimal money)
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
                return true;
            }
            catch (IOException)
            {
                Console.WriteLine("The Log file was corrupted");
                return false;
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
                return false;
            }
            //tracks money inserted


        }

        //public decimal ChangeOwed { get; set; } i dont think we need this anymore thanks DAVID
        public bool AdjustBalance(decimal change)
        {

            // if you adjust the balance and the amount is NOT negative it will change the Balance
            if (change == 0 || change == 1 || change == 2 || change == 5 || change == 10)
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

        public void GiveChange(VendingMachine vendingMachine)
        {
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string fullPath = Path.Combine(directory, file);
            decimal change = balance;

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} GIVE CHANGE: {Balance.ToString("C")} $0.00");
                    balance = 0M;
                }
                this.CreateSalesReport(vendingMachine);

                Dictionary<string, decimal> coins = new Dictionary<string, decimal>()
                {
                    ["Quarter"] = 0.25M,
                    ["Dime"] = 0.10M,
                    ["Nickel"] = 0.05M
                };
                foreach (KeyValuePair<string, decimal> coin in coins)
                {

                    while (change >= coin.Value)
                    {
                        Console.WriteLine($"Your change is: {change.ToString("C")}");
                        Thread.Sleep(800);
                        Console.Clear();
                        change -= coin.Value;
                        Console.WriteLine("**CLINK**");
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.WriteLine($"Here's a {coin.Key}");
                        Thread.Sleep(800);
                        Console.Clear();
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
            }
            
        }
        static decimal balance;
        public decimal Balance
        {
            get

            { return balance; }
        }
        public bool PrintSalesReport()
        {
            string directory = Environment.CurrentDirectory;
            string file = "SalesReport.txt";
            string fullPath = Path.Combine(directory, file);
            bool passed = false;
            try
            {
                if (File.Exists(fullPath))
                {
                    using (StreamReader sr = new StreamReader(fullPath))
                    {
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }

                    passed = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error with the sales report.");

            }
            Console.WriteLine("Please press enter to exit");
            Console.ReadLine();
            Console.Clear();
            return passed;

        }
        public bool CreateSalesReport(VendingMachine machine)
        {
            string directory = Environment.CurrentDirectory;
            string file = "SalesReport.txt";
            string fullPath = Path.Combine(directory, file);

            try
            {
                Dictionary<string, int> salesReport = new Dictionary<string, int>();
                if (File.Exists(fullPath))
                {
                    using (StreamReader sr = new StreamReader(fullPath))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] splitLine = line.Split("|");
                            salesReport[splitLine[0]] = int.Parse(splitLine[1]);
                        }
                    }
                }
                foreach (Food item in machine.foodItems)
                {
                    if (salesReport.ContainsKey(item.Name))
                    {
                        int snacksSold = salesReport[item.Name] + (item.startingSnacks - item.SnacksLeft);
                        salesReport[item.Name] = snacksSold;
                    }
                    else
                    {
                        salesReport[item.Name] = (item.startingSnacks - item.SnacksLeft);
                    }
                }
                using (StreamWriter sw = new StreamWriter(fullPath, false))
                {
                    sw.WriteLine($"{DateTime.UtcNow}");
                    foreach (KeyValuePair<string, int> item in salesReport)
                    {
                        sw.WriteLine($"{item.Key}|{item.Value}");
                    }
                }
                return true;
            }
            catch (IOException)
            {
                Console.WriteLine("The Log file was corrupted");
                return false;
            }
            catch (Exception)
            {

                Console.WriteLine("Vending machine self destructed!");
                return false;
            }







        }
    }
}
