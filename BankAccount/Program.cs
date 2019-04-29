using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to create account, 2 for deposit, press 3 for withdrawal, 4 for operations records, Z for exit");
            var input = Console.ReadLine();
            var inputResponse = string.Empty;
            Account account = null;
            while (input.ToString().ToUpper() != "Z")
            {
                if(input.ToString() == "1")
                {
                    if(account != null)
                    {
                        Console.WriteLine("Account already exists, Press 2 for deposit,  3 for withdrawal, 4 for operations records");
                    }
                    else
                    {
                        Console.WriteLine("Enter the amount to create account");
                        inputResponse = Console.ReadLine();
                        double amount;
                        if (double.TryParse(inputResponse.ToString(), out amount))
                        {
                            account = new Account(amount);
                            Console.WriteLine(String.Format("creation  of account with a balance of {0} done", amount));
                        }
                        Console.WriteLine("Press 1 to create account, 2 for deposit, press 3 for withdrawal, 4 for operations records, Z for exit");

                    }
 
                }

                if (input.ToString() == "2")
                {
                    if (account == null)
                    {
                        Console.WriteLine("Account not exists, press 1 to create it");
                    }
                    else
                    {
                        Console.WriteLine("Enter the amount of the deposit");
                        inputResponse = Console.ReadLine();
                        double amount;
                        if (double.TryParse(inputResponse.ToString(), out amount))
                        {
                            account.Deposit(amount);
                            Console.WriteLine(String.Format("deposit of {0} done", amount));

                        }
                        Console.WriteLine("Press 1 to create account, 2 for deposit, press 3 for withdrawal, 4 for operations records, Z for exit");

                    }
                }

                if (input.ToString() == "3")
                {
                    if (account == null)
                    {
                        Console.WriteLine("Account not exists, press 1 to create it");
                    }
                    else
                    {
                        Console.WriteLine("Enter the amount of the withdrawal");
                        inputResponse = Console.ReadLine();
                        double amount;
                        if (double.TryParse(inputResponse.ToString(), out amount))
                        {
                            account.Withdrawal(amount);
                            Console.WriteLine(String.Format("withdrawal of {0} done", amount));

                        }

                        Console.WriteLine("Press 1 to create account, 2 for deposit, press 3 for withdrawal, 4 for operations records, Z for exit");

                    }

                }


                if (input.ToString() == "4")
                {
                    if (account == null)
                    {
                        Console.WriteLine("Account not exists, press 1 to create it");
                    }
                    else
                    {
                        
                        string records = account.GetOperationsHistory(null, null);
                        Console.WriteLine(records);

                        Console.WriteLine("Press 1 to create account, 2 for deposit, press 3 for withdrawal, 4 for operations records, Z for exit");

                    }

                }
                input = Console.ReadLine();
            }

        }

       
    }
}
