using System;
using CashMachine.Models;

namespace CashMachine.Utils
{
    static class MenuHelper
    {
        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to the Cash Machine!");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Cash");
            Console.WriteLine("3. Deposit Cash");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");
        }

        public static void WithdrawCash()
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0)
            {
                if (withdrawAmount > (decimal)Customer.Balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return;
                }
                Console.WriteLine($"You have withdrawn ${withdrawAmount:F2}. Please take your cash.");
                Customer.Balance -= (double)withdrawAmount;
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }
        public static void DepositCash()
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
            {
                Console.WriteLine($"You have deposited ${depositAmount:F2}. Thank you!");
                Customer.Balance += (double)depositAmount;
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }
        public static void ShowInvalidOptionMessage()
        {
            Console.WriteLine("Invalid option selected. Please try again.");
        }

        public static void ShowGoodbyeMessage()
        {
            Console.WriteLine("Thank you for using the Cash Machine. Goodbye!");
        }

    }
}
