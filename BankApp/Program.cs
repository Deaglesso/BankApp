using BankApp.Exceptions;
using BankApp.Models;
using System;

//true is deposit 
//false is withdraw

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RunApp();

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
        
        public static void RunApp()
        {
            string input = "mm";


            Bank bank = new Bank();


            do
            {
            Start:
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
                            Console.WriteLine("Press 0 to return back or ENTER to continue");
                            string choice = Console.ReadLine();
                            if (choice == "0")
                            {

                                input = "mm";
                                goto Start;

                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }

                        break;


                    case "2":
                        Console.Clear();
                        Console.WriteLine(":: DEPOSIT MONEY ::");
                        if(bank.AccountsGetCount() == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Accounts!");
                            Console.WriteLine("Press any key to return!");
                            Console.ReadKey();
                            input = "mm";
                            goto Start;
                        }

                        string inputdp;
                        bool idvalid = false, amountvalid = false;

                        int iddp = 0;
                        decimal numberdp = 0;

                        while (!idvalid)
                        {

                            try
                            {
                                Console.WriteLine();
                                Console.Write("Please enter ID of account you want to deposit: ");
                                inputdp = Console.ReadLine();
                                if (int.TryParse(inputdp, out iddp) && iddp > 0)
                                {
                                    try
                                    {
                                        if (iddp <= bank.AccountsGetCount())
                                        {

                                            idvalid = true;
                                        }
                                        else
                                        {
                                            throw new AccountNotFoundException();

                                        }
                                    }
                                    catch (AccountNotFoundException e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Please Enter existing ID.");
                                        Console.WriteLine("Press 0 to return back or ENTER to continue");
                                        string choice = Console.ReadLine();
                                        if (choice == "0")
                                        {

                                            input = "mm";
                                            goto Start;

                                        }
                                        Console.Clear();
                                        Console.WriteLine(":: DEPOSIT MONEY ::\n");
                                        Console.WriteLine("Enter again:");
                                        input = "mm";
                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e.Message);
                                    }

                                }
                                else
                                {
                                    throw new InvalidAmountException();
                                }
                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }
                                Console.Clear();
                                Console.WriteLine(":: DEPOSIT MONEY ::\n");
                                Console.WriteLine("Enter again:");
                                input = "mm";
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine($"{e.Message}");

                            }

                        }
                        //

                        while (!amountvalid)
                        {
                            try
                            {
                                Console.WriteLine($"Your balance: {bank[iddp].Balance}");
                                Console.Write("Please enter amount of money you want to deposit: ");
                                inputdp = Console.ReadLine();
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
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        bank.DepositMoney(iddp, numberdp);
                        Console.WriteLine($"Deposit operation successful! {numberdp} amount deposited.");
                        Console.WriteLine($"Your new balance: {bank[iddp].Balance}");
                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(":: WITHDRAW MONEY ::");

                        if (bank.AccountsGetCount() == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Accounts!");
                            Console.WriteLine("Press any key to return!");
                            Console.ReadKey();
                            input = "mm";
                            goto Start;
                        }
                        string inputwd;
                        bool idvalidwd = false, amountvalidwd = false;

                        int idwd = 0;
                        decimal numberwd = 0;

                        while (!idvalidwd)
                        {

                            try
                            {
                                Console.WriteLine();
                                Console.Write("Please enter ID of account you want to Withdraw: ");
                                inputwd = Console.ReadLine();
                                if (int.TryParse(inputwd, out idwd) && idwd > 0)
                                {
                                    try
                                    {
                                        if (idwd <= bank.AccountsGetCount())
                                        {

                                            idvalidwd = true;
                                        }
                                        else
                                        {
                                            throw new AccountNotFoundException();

                                        }
                                    }
                                    catch (AccountNotFoundException e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Please Enter existing ID.");
                                        Console.WriteLine("Press 0 to return back or ENTER to continue");
                                        string choice = Console.ReadLine();
                                        if (choice == "0")
                                        {

                                            input = "mm";
                                            goto Start;

                                        }
                                        Console.Clear();
                                        Console.WriteLine(":: WITHDRAW MONEY ::\n");
                                        Console.WriteLine("Enter again:");
                                        input = "mm";
                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e.Message);
                                    }

                                }
                                else
                                {
                                    throw new InvalidAmountException();
                                }
                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }
                                Console.Clear();
                                Console.WriteLine(":: WITHDRAW MONEY ::\n");
                                Console.WriteLine("Enter again:");
                                input = "mm";
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine($"{e.Message}");

                            }

                        }

                        while (!amountvalidwd)
                        {
                            try
                            {
                                Console.WriteLine($"Your balance: {bank[idwd].Balance}");
                                Console.Write("Please enter amount of money you want to Withdraw: ");
                                inputwd = Console.ReadLine();
                                if (decimal.TryParse(inputwd, out numberwd) && numberwd > 0)
                                {


                                    try
                                    {
                                        bank.WithdrawMoney(idwd, numberwd);
                                        amountvalidwd = true;
                                    }
                                    catch (InsufficientFundsException e)
                                    {

                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Press 0 to return back or ENTER to continue");
                                        string choice = Console.ReadLine();
                                        if (choice == "0")
                                        {

                                            input = "mm";
                                            goto Start;

                                        }
                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e.Message);
                                    }

                                }
                                else
                                {
                                    throw new InvalidAmountException();
                                }
                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }


                        Console.WriteLine($"Withdraw operation successful! {numberwd} amount withdrew.");
                        Console.WriteLine($"Your balance: {bank[idwd].Balance}");
                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(":: LIST OF ALL ACCOUNTS :: ");
                        Console.WriteLine();
                        bank.ShowAllAccounts();
                        Console.WriteLine();
                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    //////////////////////////////////////////////////
                    case "5":
                        Console.Clear();
                        Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::");
                        if (bank.AccountsGetCount() == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Accounts!");
                            Console.WriteLine("Press any key to return!");
                            Console.ReadKey();
                            input = "mm";
                            goto Start;
                        }

                        string inputtr;
                        bool idvalidtr1 = false, amountvalidtr = false;

                        int idtr1 = 0;
                        decimal numbertr = 0;

                        while (!idvalidtr1)
                        {

                            try
                            {
                                Console.WriteLine();
                                Console.Write("Please enter ID of sender account: ");
                                inputtr = Console.ReadLine();
                                if (int.TryParse(inputtr, out idtr1) && idtr1 > 0)
                                {
                                    try
                                    {
                                        if (idtr1 <= bank.AccountsGetCount())
                                        {

                                            idvalidtr1 = true;
                                        }
                                        else
                                        {
                                            throw new AccountNotFoundException();

                                        }
                                    }
                                    catch (AccountNotFoundException e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Please Enter existing ID.");
                                        Console.WriteLine("Press 0 to return back or ENTER to continue");
                                        string choice = Console.ReadLine();
                                        if (choice == "0")
                                        {

                                            input = "mm";
                                            goto Start;

                                        }
                                        Console.Clear();
                                        Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::\n");
                                        Console.WriteLine("Enter again:");
                                        input = "mm";
                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e.Message);
                                    }

                                }
                                else
                                {
                                    throw new InvalidAmountException();
                                }
                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }
                                Console.Clear();
                                Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::\n");
                                Console.WriteLine("Enter again:");
                                input = "mm";
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine($"{e.Message}");

                            }

                        }



                        bool idvalidtr2 = false;

                        int idtr2 = 0;


                        while (!idvalidtr2)
                        {

                            try
                            {
                                Console.WriteLine();
                                Console.Write("Please enter ID of destination account: ");
                                inputtr = Console.ReadLine();
                                if (int.TryParse(inputtr, out idtr2) && idtr2 > 0)
                                {
                                    try
                                    {
                                        if (idtr2 <= bank.AccountsGetCount())
                                        {

                                            idvalidtr2 = true;
                                        }
                                        else
                                        {
                                            throw new AccountNotFoundException();

                                        }
                                    }
                                    catch (AccountNotFoundException e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Please Enter existing ID.");
                                        Console.WriteLine("Press 0 to return back or ENTER to continue");
                                        string choice = Console.ReadLine();
                                        if (choice == "0")
                                        {

                                            input = "mm";
                                            goto Start;

                                        }
                                        Console.Clear();
                                        Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::\n");
                                        Console.WriteLine("Enter again:");
                                        input = "mm";
                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e.Message);
                                    }

                                }
                                else
                                {
                                    throw new InvalidAmountException();
                                }
                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }
                                Console.Clear();
                                Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::\n");
                                Console.WriteLine("Enter again:");
                                input = "mm";
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine($"{e.Message}");

                            }

                        }


                        while (!amountvalidtr)
                        {
                            try
                            {
                                Console.WriteLine($"Source account's balance: {bank[idtr1].Balance}");
                                Console.WriteLine($"Destination account's balance: {bank[idtr2].Balance}");
                                Console.Write("Please enter amount of money you want to Transfer: ");
                                inputtr = Console.ReadLine();
                                if (decimal.TryParse(inputtr, out numbertr) && numbertr > 0)
                                {


                                    try
                                    {
                                        bank.TransferMoney(idtr1, idtr2, numbertr);
                                        amountvalidtr = true;
                                    }
                                    catch (InsufficientFundsException e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Press 0 to return back or ENTER to continue");
                                        string choice = Console.ReadLine();
                                        if (choice == "0")
                                        {

                                            input = "mm";
                                            goto Start;

                                        }
                                    }
                                    catch (Exception e)
                                    {

                                        Console.WriteLine(e.Message);
                                    }

                                }
                                else
                                {
                                    throw new InvalidAmountException();
                                }
                            }
                            catch (InvalidAmountException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press 0 to return back or ENTER to continue");
                                string choice = Console.ReadLine();
                                if (choice == "0")
                                {

                                    input = "mm";
                                    goto Start;

                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        Console.WriteLine($"Transfer operation successful! {numbertr} amount transfered.");
                        Console.WriteLine($"Source account's new balance: {bank[idtr1].Balance}");
                        Console.WriteLine($"Destination account's new balance: {bank[idtr2].Balance}");
                        Console.Write("Press any key to return back!");
                        Console.ReadKey();
                        input = "mm";
                        break;
                    ////////////////////////////////////////////////////
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

    }
}

