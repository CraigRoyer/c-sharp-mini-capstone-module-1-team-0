
using System;
using Capstone.Classes;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // setting selector for user selection
            int selector = 0;

            //restock the vending machine here
            VendingMachine vendingMachine = new VendingMachine();

            // creating logSheet for audit
            LogSheet logSheet = new LogSheet();

            // while not choosing to exit 
            while (selector != 3)
            {
                Console.Clear();

                // greeting screen
                Console.WriteLine($"Hello Patron! Please enter" +
                    $"{Environment.NewLine}(1)Display Vending Machine Items" +
                    $"{Environment.NewLine}(2)Purchase" +
                    $"{Environment.NewLine}(3)Exit");

                // grabbing user selection
                string selection = Console.ReadLine();

                Console.Clear();

                // while user selection is NOT a useable or valid input.
                while (!int.TryParse(selection, out int num))
                {
                    // if user input is spelled out instead of an INT return this for another selecton
                    Console.WriteLine($"Please enter a NUMBER between 1 - 3");
                    selection = Console.ReadLine();
                    Console.Clear();
                }
                selector = int.Parse(selection);

                // if they choose to dispaly items
                if (selector == 1)
                {
                    Console.Clear();

                    // calling method from VM class
                    vendingMachine.DisplayItems(logSheet);
                }
                // if user chooses to purchase an item
                else if (selector == 2)
                {
                    Console.Clear();

                    int secondSelector = 0;
                    while (secondSelector != 3)
                    {
                        // Second screen list, similar to above
                        Console.WriteLine($"(1) Feed Money " +
                            $"{Environment.NewLine}(2) Select Product" +
                            $"{Environment.NewLine}(3) Finish Transaction");
                        string secondScreenSelect = Console.ReadLine();
                        Console.Clear();

                        // if user enters an invalid input
                        while (!int.TryParse(secondScreenSelect, out int num))
                        {
                            Console.WriteLine($"Please enter a number between 1 - 3");
                            secondScreenSelect = Console.ReadLine();
                            Console.Clear();
                        }
                        secondSelector = int.Parse(secondScreenSelect);

                        // if user chooses to insert cash
                        if (secondSelector == 1)
                        {
                            Console.WriteLine("Please insert cash.");
                            string cashInserted = Console.ReadLine();
                            Console.Clear();

                            while (!decimal.TryParse(cashInserted, out decimal num))
                            {

                                Console.WriteLine($"Please insert CaSh pLeAsE.");
                                cashInserted = Console.ReadLine();
                                Console.Clear();
                            }

                            decimal cash = decimal.Parse(cashInserted);
                            logSheet.AdjustBalance(cash, logSheet);
                        }

                        //purchase item
                        if (secondSelector == 2)
                        {
                            Console.Clear();
                            vendingMachine.PurchaseFood(logSheet);
                        }

                        //cashout and go back to main screen
                        if (secondSelector == 3)
                        {
                            Console.Clear();
                            logSheet.GiveChange();
                        }
                    }
                }
            }
        }
    }
}
