using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class Operation
    {
        public DateTime Date { get; private set; }
        public Amount Amount { get; private set; }

        public Operation(Amount amount, DateTime date)
        {
            Date = date;
            Amount = amount;
        }

        public override abstract string ToString();

    }

}
