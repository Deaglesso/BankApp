﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal class Bank
    {
        private List<Account> Accounts { get; set; } = new List<Account>();

        public void CreateAccount(decimal startBalance)
        {
            Account account = new Account();
            account.Deposit(startBalance);
            Accounts.Add(account);
        }
        public void DepositMoney(int id,decimal amount) 
        {
            Accounts[id-1].Deposit(amount);
            

        }
        public void WithdrawMoney(int id, decimal amount)
        {
            Accounts[id-1].Withdraw(amount);
        }

        public void TransferMoney(int fromId,int toId,decimal amount)
        {
            Accounts[fromId-1].Withdraw(amount);
            Accounts[toId-1].Deposit(amount);

        }

        public void ShowAllAccounts()
        {
            foreach (Account account in Accounts)
            {
                Console.WriteLine($"[ID: {account.AccountID}] {account.Balance}");
            }
        }

        public int AccountsGetCount()
        {
            return Accounts.Count;
        }

        public Account this[int index] 
        {  
            get { return Accounts[index-1]; } 
        }


    }
}
