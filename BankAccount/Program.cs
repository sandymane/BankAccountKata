using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DisplayMenu();
                var input = Console.ReadLine();
                Account account = null;
                DateTime date = DateTime.Now;
             
                while (input.ToString().ToUpper() != "Z")
                {
                    if (input.ToString() == "1")
                    {
                        if (account != null)
                        {
                            Console.WriteLine("Account already exists");
                            DisplayMenu();
                        }
                        else
                        {
                            Console.WriteLine("Enter the amount to create account");
                            Amount amount = ConvertResponseInAmount();
                            if(amount.Value > -1)
                            {
                                account = new Account(amount, date);
                                if(amount.isPositive())
                                {
                                    Console.WriteLine($"Creation  of account with an initial deposit of {amount} done");
                                }
                                else
                                {
                                    Console.WriteLine($"Creation  of account done");
                                }
                            }
                            DisplayMenu();
                        }

                    }

                    else if (input.ToString() == "2")
                    {
                        if(CheckIfAccountExistsAndAdvertClient(account))
                        {
                            Console.WriteLine("Enter the amount of the deposit");
                            Amount amount = ConvertResponseInAmount();
                            if (amount.isPositive())
                            {
                                account.Deposit(amount, date);
                                Console.WriteLine($"Deposit of {amount} done");

                            }
                            DisplayMenu();
                        }
                    }
                    else if (input.ToString() == "3")
                    {
                        if (CheckIfAccountExistsAndAdvertClient(account))
                        {
                            Console.WriteLine("Enter the amount of the withdrawal");
                            Amount amount = ConvertResponseInAmount();
                            if (amount.isPositive())
                            {
                                account.Withdrawal(amount, date);
                                Console.WriteLine($"Withdrawal of {amount} done");
                            }
                            DisplayMenu();
                        }

                    }
                    else if (input.ToString() == "4")
                    {
                        if (CheckIfAccountExistsAndAdvertClient(account))
                        {
                            string records = account.GetOperationsHistory();
                            Console.WriteLine(records);
                            DisplayMenu();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Instruction not found");
                        DisplayMenu();
                    }
                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                Console.ReadKey();
            }

        }

        private static  Amount ConvertResponseInAmount()
        {
            var inputResponse = Console.ReadLine();
            double amountValue;
            if (double.TryParse(inputResponse.ToString().Replace(".", ","), out amountValue))
            {
                return new Amount(amountValue);
            }
            else
            {
                Console.WriteLine("You have to tap a number");
                return new Amount(-1);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Press :");
            Console.WriteLine("1) to create account");
            Console.WriteLine("2) to make a deposit");
            Console.WriteLine("3) to make a withdrawal");
            Console.WriteLine("4) to see the operations records");
            Console.WriteLine("Z) for exit");
        }

        private static bool CheckIfAccountExistsAndAdvertClient(Account account)
        {
            if (account == null)
            {
                Console.WriteLine("Account not exists, press 1 to create it");
                return false;
            }
            return true;
        }

    }

}
