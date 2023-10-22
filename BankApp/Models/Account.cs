using BankApp.Exceptions;
using BankApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal class Account : IAccount
    {
        private static int Count = 1;
        public int AccountID { get;  }

        public decimal Balance { get; set; }

        private List<Transaction> Transactions { get; set; } = new List<Transaction>();
        

        public Account()
        {
            AccountID = Count++;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidAmountException();
            }

            else 
            { 
                Balance += amount;
                Transaction transaction = new Transaction(amount,true);
                Transactions.Add(transaction);
            }
        }

        public void Withdraw(decimal amount)
        {
            if(amount < 0)
            {
                throw new InvalidAmountException();
            }

            else if(Balance >= amount) 
            {
                Balance -= amount;
                Transaction transaction = new Transaction(amount, false);
                Transactions.Add(transaction);
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
        public string GetTransactions()
        {
            string str;
            foreach (var transaction in Transactions)
            {
                if (transaction.TransactionType)
                {
                    str = "Deposit";
                }
                else
                {
                    str = "Withdraw";
                }
                return $"Transaction ID: {transaction.TransactionID} Type: {str} Amount: {transaction.Amount} Date: {transaction.TransactionDate}";
            }
            return null;
        }
        public void ShowTransactions()
        {
            string str;
            
            foreach (var transaction in Transactions)
            {
                if (transaction.TransactionType)
                {
                    str = "Deposit";
                }
                else
                {
                    str = "Withdraw";
                }
                Console.WriteLine($"Transaction ID: {transaction.TransactionID} | Type: {str} | Amount: {transaction.Amount} | Date: {transaction.TransactionDate}");
            }
        }
    }
}
