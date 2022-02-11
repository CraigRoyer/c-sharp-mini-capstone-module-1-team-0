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
        public List<object> foodItems = new List<object>();
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
                        string[] splitLine = line.Split("|");
                        string className = splitLine[splitLine.Length - 1];
                        object[] detailsForConstructor = new object[]
                        {
                        splitLine[0],
                        splitLine[1],
                        decimal.Parse(splitLine[2])
                        };
                        object item = Activator.CreateInstance(Type.GetType($"Capstone.Classes.{className}"), detailsForConstructor);

                        foodItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The vending machine guy messed up");
            }

            //populate vending machine here nerd
            foodItems[0].GetType().GetMethod("PrintMessage").Invoke(foodItems[0], null);
            //will print "thing"
        }

        public void PurchaseFood(LogSheet logsheet)
        {

        }


        public void DisplayItems()
        {



        }






        public void GiveMessage()
        {

        }
    }
}
