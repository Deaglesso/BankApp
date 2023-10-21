using BankApp.Models;

//true is deposit 
//false is withdraw

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Console.WriteLine("Welcome to bank");
        }
    }
}