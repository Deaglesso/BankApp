using BankApp.Exceptions;
using BankApp.Models;
using System;
using System.ComponentModel.Design;

//true is deposit 
//false is withdraw

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //non optimized try catch
            //tested
            //RunApp();
            


            //optimized try catch
            //not tested
            //UPDATE : MOSTLY TESTED AND MUCH BETTER USE RUNAPP2
            RunApp2();

        }

        public static void RenderMainMenu()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("WELCOME TO BANK APPLICATION");
            Console.WriteLine("===========================");
            Console.WriteLine("     :: MAIN MENU ::\n");
            Console.WriteLine("[1] Create new Account");
            Console.WriteLine("[2] Deposit Money");
            Console.WriteLine("[3] Withdraw Money");
            Console.WriteLine("[4] List of all Accounts");
            Console.WriteLine("[5] Transfer between");
            Console.WriteLine("[0] Exit");
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
                            if (decimal.TryParse(inputcr, out numbercr) && numbercr >= 0)
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



        public static void RunApp2()
        {
            string input = "mm";
            //for case 2
            string inputdp;
            bool idvalid = false, amountvalid = false;
            int iddp = 0;
            decimal numberdp = 0;

            //for case 3
            string inputwd;
            bool idvalidwd = false, amountvalidwd = false;
            int idwd = 0;
            decimal numberwd = 0;

            //for case 5
            string inputtr;
            bool idvalidtr1 = false, amountvalidtr = false;

            int idtr1 = 0;
            decimal numbertr = 0;

            bool idvalidtr2 = false;

            int idtr2 = 0;



            Bank bank = new Bank();


            do
            {
            Start:
                try
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

                            
                                if (decimal.TryParse(inputcr, out numbercr) && numbercr >= 0)
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



                            
                            

                            break;


                        case "2":
                            


                            Console.Clear();
                            Console.WriteLine(":: DEPOSIT MONEY ::");
                            if (bank.AccountsGetCount() == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("No Accounts!");
                                Console.WriteLine("Press any key to return!");
                                Console.ReadKey();
                                input = "mm";
                                goto Start;
                            }

                            

                            while (!idvalid)
                            {

                                
                                    Console.WriteLine();
                                    Console.Write("Please enter ID of account you want to deposit: ");
                                    inputdp = Console.ReadLine();
                                    if (int.TryParse(inputdp, out iddp) && iddp > 0)
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
                                    else
                                    {
                                        throw new InvalidAmountException();
                                    }
                                
                                

                            }
                            //

                            while (!amountvalid)
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
                                        idvalid = false;
                                        amountvalid = false;
                                        iddp = 0;
                                        numberdp = 0;
                                    
                                        throw new InvalidAmountException();
                                    }
                                
                                
                            }

                            bank.DepositMoney(iddp, numberdp);
                            Console.WriteLine($"Deposit operation successful! {numberdp} amount deposited.");
                            Console.WriteLine($"Your new balance: {bank[iddp].Balance}");
                            Console.Write("Press any key to return back!");
                            Console.ReadKey();
                            idvalid = false;
                            amountvalid = false;
                            iddp = 0;
                            numberdp = 0;
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
                            

                            while (!idvalidwd)
                            {

                                
                                    Console.WriteLine();
                                    Console.Write("Please enter ID of account you want to Withdraw: ");
                                    inputwd = Console.ReadLine();
                                    if (int.TryParse(inputwd, out idwd) && idwd > 0)
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
                                    else
                                    {
                                        throw new InvalidAmountException();
                                    }
                                
                                

                            }
                            if(bank[idwd].Balance == 0)
                            {
                                Console.WriteLine("You cannot withdraw with 0 balance.");

                                
                                input = "mm";
                                throw new InsufficientFundsException();
                                
                            }
                            while (!amountvalidwd)
                            {
                                
                                    Console.WriteLine($"Your balance: {bank[idwd].Balance}");
                                    Console.Write("Please enter amount of money you want to Withdraw: ");
                                    inputwd = Console.ReadLine();
                                    if (decimal.TryParse(inputwd, out numberwd) && numberwd > 0)
                                    {
                                        if(numberwd <= bank[idwd].Balance)
                                        {
                                        bank.WithdrawMoney(idwd, numberwd);
                                        Console.WriteLine($"Withdraw operation successful! {numberwd} amount withdrew.");
                                        Console.WriteLine($"Your new balance: {bank[idwd].Balance}");
                                        Console.Write("Press any key to return back!");
                                        Console.ReadKey();
                                        
                                        
                                        
                                        numberwd = 0;
                                        amountvalidwd = true;
                                        
                                        goto Start;
                                        }
                                        else {

                                        amountvalidwd = false;

                                        numberwd = 0;

                                        idvalidwd = false;
                                        idwd = 0;
                                        throw new InsufficientFundsException();



                                    }
                                            
                                    }
                                    else
                                    {
                                    
                                    amountvalidwd = false;
                                    
                                    numberwd = 0;

                                    idvalidwd = false;
                                    idwd = 0;

                                    throw new InvalidAmountException();

                                    }
                                
                                
                            }


                            Console.WriteLine($"Withdraw operation successful! {numberwd} amount withdrew.");
                            Console.WriteLine($"Your new balance: {bank[idwd].Balance}");
                            Console.Write("Press any key to return back!");
                            Console.ReadKey();
                            idvalidwd = false;
                            amountvalidwd = false;
                            idwd = 0;
                            numberwd = 0;
                            amountvalidwd = true;
                            input = "mm";
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine(":: LIST OF ALL ACCOUNTS :: ");
                            Console.WriteLine();
                            
                            if(bank.AccountsGetCount() != 0)
                            {
                                bank.ShowAllAccounts();
                            }
                            else
                            {
                                Console.WriteLine("No Accounts");
                                Console.WriteLine("Press any key to return.");
                                Console.ReadKey();
                                input = "mm";
                                goto Start;
                            }
                            Console.WriteLine();

                            Console.WriteLine("Press enter ID to view Transaction history or 0 to return.");
                            string choice = Console.ReadLine();
                            int id4;
                            if (choice == "0")
                            {
                                input = "mm";
                                goto Start;
                            }
                            else
                            {
                                if (int.TryParse(choice, out id4) && id4 > 0)
                                {

                                    if (id4 <= bank.AccountsGetCount())
                                    {

                                        idvalid = true;
                                        Console.WriteLine($"{id4} account's transaction list:");
                                        if (bank[id4].GetTransactions() == null)
                                        {
                                            Console.WriteLine("Transaction history is empty!");
                                            Console.WriteLine("Press any key to return.");

                                        }
                                        else
                                        {
                                            bank[id4].ShowTransactions();
                                            Console.WriteLine("Press any key to return.");

                                        }

                                        Console.ReadKey();
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

                            
                            break;
                        //////////////////////////////////////////////////
                        case "5":
                            Console.Clear();
                            Console.WriteLine(":: TRANSFER BETWEEN ACCOUNTS ::");
                            if (bank.AccountsGetCount() <2)
                            {
                                Console.WriteLine();
                                Console.WriteLine("No Accounts!");
                                Console.WriteLine("Press any key to return!");
                                Console.ReadKey();
                                input = "mm";
                                goto Start;
                            }

                            

                            while (!idvalidtr1)
                            {

                                
                                    Console.WriteLine();
                                    Console.Write("Please enter ID of sender account: ");
                                    inputtr = Console.ReadLine();
                                    if (int.TryParse(inputtr, out idtr1) && idtr1 > 0)
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
                                    else
                                    {
                                        throw new InvalidAmountException();
                                    }
                                
                                
                            }

                            


                            while (!idvalidtr2)
                            {

                                
                                    Console.WriteLine();
                                    Console.Write("Please enter ID of destination account: ");
                                    inputtr = Console.ReadLine();
                                    if (int.TryParse(inputtr, out idtr2) && idtr2 > 0)
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
                                    else
                                    {
                                        throw new InvalidAmountException();
                                    }
                                
                                
                                

                            }

                            if (idtr1 == idtr2)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Cannot transfer between same accounts!");
                                Console.WriteLine("Press any key to return!");
                                Console.ReadKey();
                                input = "mm";
                                goto Start;
                            }
                            while (!amountvalidtr)
                            {
                                
                                
                                    Console.WriteLine($"Source account's balance: {bank[idtr1].Balance}");
                                    Console.WriteLine($"Destination account's balance: {bank[idtr2].Balance}");
                                    Console.Write("Please enter amount of money you want to Transfer: ");
                                    inputtr = Console.ReadLine();
                                    if (decimal.TryParse(inputtr, out numbertr) && numbertr > 0)
                                    {
                                        if(numbertr <= bank[idtr1].Balance)
                                        {
                                        bank.TransferMoney(idtr1, idtr2, numbertr);

                                        amountvalidtr = true;
                                        Console.WriteLine($"Transfer operation successful! {numbertr} amount transfered.");
                                        Console.WriteLine($"Source account's new balance: {bank[idtr1].Balance}");
                                        Console.WriteLine($"Destination account's new balance: {bank[idtr2].Balance}");
                                        Console.Write("Press any key to return back!");
                                        Console.ReadKey();
                                        idvalidtr1 = false;
                                        amountvalidtr = false;

                                        idtr1 = 0;
                                        numbertr = 0;

                                        idvalidtr2 = false;

                                        idtr2 = 0;
                                        input = "mm";
                                        goto Start;
                                    }
                                    else
                                    {
                                        amountvalidtr = false;

                                        numbertr = 0;

                                        idvalidtr1 = false;
                                        idvalidtr2 = false;

                                        idtr1 = 0;
                                        idtr2 = 0;
                                        throw new InsufficientFundsException();
                                    }
              
                                            
                                    }
                                    else
                                    {
                                    idvalidtr1 = false;
                                    idvalidtr2 = false;
                                    amountvalidtr = false;

                                    idtr1 = 0;
                                    idtr2 = 0;
                                    numbertr = 0;


                                    throw new InvalidAmountException();
                                    }
                            }



                            idvalidtr1 = false;
                            amountvalidtr = false;

                            idtr1 = 0;
                            numbertr = 0;

                            idvalidtr2 = false;

                            idtr2 = 0;

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

                }
                catch (Exception e)
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
                
                

            } while (input != "0");
        }



    }
}

