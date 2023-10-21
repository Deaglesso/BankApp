using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal class Transaction
    {
		//Fields
		
		private decimal _amount;
		private bool _transactionType;
		private static int Count = 1;


		//Properties
		public string TransactionID
		{
			get;
			
		}


		public decimal Amount
		{
			get { return _amount; }
			set 
			{
				if(value > 0)
				{
					_amount = value;
				}
			}
		}


		public DateTime TransactionDate
		{
			get;
			
		}


		public bool TransactionType
		{
			get { return _transactionType; }
			set 
			{ 
				if (value || !value) { 
					_transactionType = value;
                }
            }
		}

        public Transaction(decimal amount, bool transactionType)
        {
			TransactionID = $"TID{Count++}";
			Amount = amount;
			TransactionDate = DateTime.Now;
			TransactionType = transactionType;

            
        }




    }
}
