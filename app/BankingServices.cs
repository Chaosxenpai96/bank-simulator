using System;

namespace ATMApp.Services
{
    public static class BankingServices
    {
        private static double lastTransactionAmount = 0;

        
        public static double GetBalance(double balance)
        {
            return balance;
        }

        
        public static bool Deposit(ref double balance, double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                lastTransactionAmount = amount;
                return true;
            }

            return false;
        }

        
        public static void Withdraw(
            ref double balance,
            double amount,
            out bool isSuccessful)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                lastTransactionAmount = -amount; 
                isSuccessful = true;
            }
            else
            {
                isSuccessful = false;
            }
        }

        
        public static double GetLastTransaction()
        {
            return lastTransactionAmount;
        }
    }
}
