using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class MachineScreenFunctions
    {
        public int FirstScreen()
        {
            Console.WriteLine($"Welcome to Snack Zaddy 3000:" +
                    $"{Environment.NewLine}(1)Display Vending Machine Items" +
                    $"{Environment.NewLine}(2)Purchase" +
                    $"{Environment.NewLine}(3)Exit");

            string selection = Console.ReadLine();
            Console.Clear();

            // while user selection is NOT a useable or valid input.
            while (!int.TryParse(selection, out int num))
            {
                // if user input is spelled out instead of an INT return this for another selecton
                Console.WriteLine($"Please enter a number between 1 - 3");
                selection = Console.ReadLine();
                Console.Clear();
            }

            return int.Parse(selection);
        }

        public int SecondScreen()
        {

            // Second screen list, similar to above
            Console.WriteLine($"(1) Feed Money " +
                $"{Environment.NewLine}(2) Select Product" +
                $"{Environment.NewLine}(3) Finish Transaction");
            string selectString = Console.ReadLine();
            Console.Clear();

            // if user enters an invalid input
            while (!int.TryParse(selectString, out int num))
            {
                Console.WriteLine($"Please enter a number between 1 - 3");
                selectString = Console.ReadLine();
                Console.Clear();
            }

            return int.Parse(selectString);

        }
        public void InsertCash(LogSheet logSheet)
        {
            Console.WriteLine("Please insert cash in increments of $1, $2, $5, or $10:");
            string cashInserted = Console.ReadLine();
            Console.Clear();

            while (!decimal.TryParse(cashInserted, out decimal num))
            {

                Console.WriteLine($"Please insert CaSh pLeAsE.");
                cashInserted = Console.ReadLine();
                Console.Clear();
            }
            decimal cash = decimal.Parse(cashInserted);
            logSheet.AdjustBalance(cash);
        }
        

    }
}
