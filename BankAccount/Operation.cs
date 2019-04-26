using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class Operation
    {
        protected readonly DateTime _date;
        protected readonly double Amount;

        public Operation(double amount, DateTime date)
        {
            _date = date;
            Amount = amount;

        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

        }

        public override abstract string ToString();


    }

    public enum TypeOperation
    {
        Deposit,
        WithDrawal
    }
}
