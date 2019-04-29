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
        protected readonly double _amount;

        public Operation(double amount, DateTime date)
        {
            _date = date;
            _amount = amount;

        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

        }

        public double Amount
        {
            get
            {
                return _amount;
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
