using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string name = "Account not found!") : base(name) { }    
        
    }
}
