using System;
using Capstone.Classes;
using System.Collections.Generic;
namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            int selector = 0;
            while (selector != 3)
            {
                Console.WriteLine($"Hello Patron! Please enter" +
                    $"{Environment.NewLine}(1)Display Vending Machine Items" +
                    $"{Environment.NewLine}(2)Purchase" +
                    $"{Environment.NewLine}(3)Exit");

                string selection = Console.ReadLine();

                while (!int.TryParse(selection, out int num))
                {
                    Console.WriteLine($"Please enter a number between 1 - 3");
                }
               selector = int.Parse(selection);


                new VendingMachine().DisplayItems();
            }

           


            

        }
    }
}
