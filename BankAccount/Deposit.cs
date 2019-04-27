using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Deposit : Operation
    {
        public Deposit(double amount, DateTime date) : base(amount, date)
        {

        }

        public override string ToString()
        {
            return String.Format("DEPOSIT | {0} | {1} | {1}", Date.Date.ToShortDateString(), Amount);
        }
    }
}
