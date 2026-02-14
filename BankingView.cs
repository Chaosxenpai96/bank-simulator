using System;
using ATMApp.Services;

namespace ATMApp.View
{
    public static class BankingView
    {
        public static void Run()
        {
            Console.WriteLine("=== Simple ATM System ===");
            bool isRunning = true;

            // Create AccountService instance
            var accountService = new AccountService();

            while (isRunning)
            {
                Console.WriteLine("\nPlease Select an Option:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Cash");
                Console.WriteLine("3. Withdraw Cash");
                Console.WriteLine("4. View Mini Statement");
                Console.WriteLine("5. Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CheckBalance(accountService);
                        break;

                    case "2":
                        DepositCash(accountService);
                        break;

                    case "3":
                        WithdrawCash(accountService);
                        break;

                    case "4":
                        ViewMiniStatement(accountService);
                        break;

                    case "5":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input, Please Try Again");
                        break;
                }
            }

            Console.WriteLine("Thank you for using Simple ATM");
        }

        private static void CheckBalance(AccountService accountService)
        {
            var balance = accountService.GetBalance();
            Console.WriteLine($"Current Balance is: ${balance}");
        }

        private static void DepositCash(AccountService accountService)
        {
            Console.Write("Enter Amount to Deposit: $");

            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                accountService.Deposit(amount);
                Console.WriteLine($"Successfully Deposited: ${amount}");
                Console.WriteLine($"New Balance: ${accountService.GetBalance()}");
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }

        private static void WithdrawCash(AccountService accountService)
        {
            Console.Write("Enter Amount to Withdraw: $");

            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                bool success = accountService.Withdraw(amount);

                if (success)
                {
                    Console.WriteLine($"Successfully Withdrawn: ${amount}");
                    Console.WriteLine($"New Balance: ${accountService.GetBalance()}");
                }
                else
                {
                    Console.WriteLine("Unsuccessful Withdrawal due to insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }

        private static void ViewMiniStatement(AccountService accountService)
        {
            var transactionHistory = accountService.GetTransactionHistory();

            if (transactionHistory.Count == 0)
            {
                Console.WriteLine("No Transaction History Found.");
            }
            else
            {
                Console.WriteLine("\n=== Mini Statement ===");
                foreach (var transaction in transactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }
        }
    }
}
