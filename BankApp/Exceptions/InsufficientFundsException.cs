﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message = "Insufficient Funds!"):base(message) 
        {
             
        }
    }
}
