using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Withdrawal : Operation
    {
        public Withdrawal(double amount, DateTime date) : base(amount, date)
        {

        }

        public override string ToString()
        {
            return String.Format("WITHDRAWAL | {0} | {1} | -{2}", Date.Date, Date.Hour, Amount);
        }
    }
}
