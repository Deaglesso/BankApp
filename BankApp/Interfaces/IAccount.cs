using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Interfaces
{
    internal interface IAccount
    {
        //Properties
        int AccountID { get; }
        decimal Balance { get; }

        //Methods
        public void Deposit(decimal amount);
        public void Withdraw(decimal amount);

    }
}
