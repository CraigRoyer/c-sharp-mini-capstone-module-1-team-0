using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime;
namespace Capstone.Classes
{
    public class VendingMachine
    {
        public List<Food> foodItems = new List<Food>();
        public VendingMachine()
        {

            string directory = Environment.CurrentDirectory;
            string fileName = @"vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);

            //read file and fill foodItems list with the food
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        //reading each line of the csv file
                        string[] splitLine = line.Split("|");
                        //separating the info from each line
                        string className = splitLine[splitLine.Length - 1];
                        string location = splitLine[0];
                        string itemName = splitLine[1];
                        decimal price = decimal.Parse(splitLine[2]);
                        //retrieving the classname, location, name, price
                        
                        if (className == "Candy")
                        {
                            Candy item = new Candy(location, itemName, price);
                            foodItems.Add(item);
                        }
                        if (className == "Chip")
                        {
                            Chip item = new Chip(location, itemName, price);
                            foodItems.Add(item);
                        }
                        if (className == "Drink")
                        {
                            Drink item  = new Drink(location, itemName, price);
                            foodItems.Add(item);
                        }
                        if (className == "Gum")
                        {
                            Gum item  = new Gum(location, itemName, price);
                            foodItems.Add(item);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The vending machine guy messed up...BIG TIME");
            }

        }

        public void PurchaseFood(LogSheet logsheet)
        {
            this.DisplayItems(logsheet);
            Console.WriteLine("Please enter item key:");//updates inventory and logsheet
            string order = Console.ReadLine();
            Console.Clear();

            foreach (Food item in foodItems)
            {
                if (order.ToUpper() == item.Location)
                {
                    if (item.SnacksLeft == 0)
                    {
                        Console.WriteLine("SOLD OUT :_(");
                    }
                    else
                    {
                        if (logsheet.AdjustBalance(item, logsheet)) //calling adjustbalance...this is returning a bool AND adjusting our balance
                        {
                            item.PrintMessage();//dispense food - print message
                            item.SnacksLeft--; // track inventory

                        }
                        
                    }
                }
            }
        }


        public void DisplayItems(LogSheet logSheet)
        {
            foreach (Food item in foodItems)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Cost} | Remaining: {item.SnacksLeft}");
            }
            logSheet.AdjustBalance(0, logSheet);

        }

    }
}
