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

        private static List<Transaction> Transactions { get; set; } = new List<Transaction>();
        

        public Account(decimal balance)
        {
            AccountID = Count++;
            Balance = balance;
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
    }
}
