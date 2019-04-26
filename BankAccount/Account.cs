using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private double Balance;
        private List<Operation> Operations;

        public Account(double balance)
        {
            Balance = balance;
            Operations = new List<Operation>();
        }

        public void MakeDeposit(double amount)
        {
            if(amount > 0)
            {
                Balance += amount;
                Operation deposit = new Deposit(amount, DateTime.Now);
                Operations.Add(deposit);
            }
        }

        public void MakeWithdrawal(double amount)
        {
            if (amount > 0)
            {
                Balance -= amount;
                Operation withdrawal = new Withdrawal(amount, DateTime.Now);
                Operations.Add(withdrawal);
            }
        }

        public double GetBalanceValue()
        {
            return Balance;
        }

       
    }
}
