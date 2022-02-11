
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

                selector = new MachineScreenFunctions().FirstScreen();
                
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
                        secondSelector = new MachineScreenFunctions().SecondScreen();

                        // if user chooses to insert cash
                        if (secondSelector == 1)
                        {
                            new MachineScreenFunctions().InsertCash(logSheet);                            
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
