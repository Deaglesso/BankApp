using BankApp.Exceptions;
using BankApp.Models;

//true is deposit 
//false is withdraw

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = "mm";


            Bank bank = new Bank();
            

            do
            {
                if (input == "mm")
                {
                    Console.Clear();
                    RenderMainMenu();
                    Console.Write("Select your option (0-5): ");
                    input = Console.ReadLine().Trim();
                }
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(":: ACCOUNT CREATION ::");
                        Console.Write("Please enter starting balance of account: ");
                        string inputcr = Console.ReadLine();
                        decimal numbercr;

                        try
                        {
                            if (decimal.TryParse(inputcr, out numbercr) && numbercr > 0)
                            {
                                Console.WriteLine($"Account created with {numbercr} balance!");
                                bank.CreateAccount(numbercr);
                                Console.Write("Press any key to return back!");
                                Console.ReadKey();
                                input = "mm";

                            }
                            else
                            {
                                throw new InvalidAmountException();

                            }



                        }
                        catch (InvalidAmountException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Write("Press any key to try again!");
                            Console.ReadKey();
                            input = "1";
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;



                    case "2":
                        Console.Clear();
                        Console.WriteLine(":: DEPOSIT MONEY ::");

                        Console.Write("Please enter ID of account you want to deposit: ");
                        string inputdp = Console.ReadLine();
                        bool idvalid = false, amountvalid = false;
                        int iddp = 0;
                        decimal numberdp = 0;

                        while (!idvalid) 
                        { 

                            if (int.TryParse(inputdp, out iddp ))
                            {
                                if (iddp>0 && iddp <= bank.AccountsGetCount())
                                {

                                    idvalid = true;
                                }
                                else
                                {
                                    throw new AccountNotFoundException();

                                }
                            }
                            else
                            {
                                throw new InvalidAmountException();
                            } 
                        }
                        //
                        Console.Write("Please enter amount of money you want to deposit: ");
                        inputdp = Console.ReadLine();
                        while (!amountvalid)
                        {
                            try
                            {
                                if (decimal.TryParse(inputdp, out numberdp) && numberdp > 0)
                                {
                                    amountvalid = true;
                                }
                                else
                                {
                                    throw new InvalidAmountException();

                                }



                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.Write("Press any key to try again!");
                                Console.ReadKey();
                                input = "1";
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        bank.DepositMoney(iddp, numberdp);
                        Console.WriteLine($"Deposit operation successful! {numberdp} amount deposited.");

                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(":: WITHDRAW MONEY ::");

                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(":: LIST OF ALL ACCOUNTS :: ");
                        bank.ShowAllAccounts();

                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::");

                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        input = "0";

                        break;
                    default:
                        Console.Write("Select valid option! Press any key to re-enter option.");
                        Console.ReadKey();
                        input = "mm";
                        break;
                }

            } while (input != "0");

        }

        public static void RenderMainMenu()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("WELCOME TO BANK APPLICATION");
            Console.WriteLine("===========================");
            Console.WriteLine("     :: MAIN MENU ::\n");
            Console.WriteLine("1. Create new Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. List of all Accounts");
            Console.WriteLine("5. Transfer between");
            Console.WriteLine("0. Exit");
        }
    }
}