using System;

namespace BankAccount
{
    public class Withdrawal : Operation
    {
        public Withdrawal(double amount, DateTime date) : base(amount, date)
        {

        }

        public override string ToString()
        {
            return String.Format("WITHDRAWAL | {0} | {1}        |", Date.Date.ToShortDateString(), _amount);
        }
    }
}
