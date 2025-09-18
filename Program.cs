using System;
using CashMachine.Utils;
using CashMachine.Models;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("John Doe", "1234567890");
            BankAccount account = new BankAccount(1000);
            Customer customer = new Customer(person, account, "1234");

            const int MAX_ATTEMPTS = 3;
            int attempts = 0;
            bool isAuthenticated = false;

            while (attempts < MAX_ATTEMPTS && !isAuthenticated)
            {
                Console.Write("Enter your PIN: ");
                string inputPin = Console.ReadLine()!;

                if (customer.Authenticate(inputPin))
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

            bool exit = false;

            while (!exit)
            {
                MenuHelper.ShowMenu();
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: {customer.Account.Balance:C}");
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw: $");
                        MenuHelper.WithdrawCash(customer);
                        break;

                    case "3":
                        Console.Write("Enter amount to deposit: $");
                        MenuHelper.DepositCash(customer);
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
