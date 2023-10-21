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
        public string AccountID { get;  }

        public decimal Balance { get; set; }

        private List<Transaction> Transactions { get; set; }
        

        public Account(decimal balance)
        {
            AccountID = $"ACC{Count++}";
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
