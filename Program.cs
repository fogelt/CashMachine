using System;
using CashMachine.Utils;
using CashMachine.Models;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_ATTEMPTS = 3;
            int attempts = 0;
            bool isAuthenticated = false;

            // Authentication loop
            while (attempts < MAX_ATTEMPTS && !isAuthenticated)
            {
                Console.Write("Enter your PIN: ");
                string inputPin = Console.ReadLine();

                if (inputPin == Customer.PIN)
                {
                    isAuthenticated = true;
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Incorrect PIN. Please try again.");
                }
            }

            if (!isAuthenticated)
            {
                Console.WriteLine("Maximum attempts exceeded. Exiting...");
                return;
            }

            decimal balance = 1000.00m;
            bool exit = false;

            while (!exit)
            {
                MenuHelper.ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: ${balance:F2}");
                        break;
                    case "2":
                        Console.Write("Enter amount to withdraw: $");
                        MenuHelper.WithdrawCash();
                        break;
                    case "3":
                        {
                        Console.Write("Enter amount to deposit: $");
                        MenuHelper.DepositCash();
                        }
                        break;
                    case "4":
                        exit = true;
                        MenuHelper.ShowGoodbyeMessage();
                        break;
                    default:
                        MenuHelper.ShowInvalidOptionMessage();
                        break;
                }
            }
        }
    }
}