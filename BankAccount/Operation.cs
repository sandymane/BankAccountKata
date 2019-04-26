using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class Operation
    {
        protected readonly DateTime Date;
        protected readonly double  Amount;

        public Operation(double amount, DateTime date)
        {
            Date = date;
            Amount = amount;
             
        }

        public abstract override string ToString();
        

    }

    public enum TypeOperation
    {
        Deposit,
        WithDrawal
    }
}
