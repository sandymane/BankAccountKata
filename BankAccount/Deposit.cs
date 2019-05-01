using System;

namespace BankAccount
{
    public class Deposit : Operation
    {
        public Deposit(Amount amount, DateTime date) : base(amount, date)
        {

        }

        public override string ToString()
        {
            return $"DEPOSIT    | {Date.Date.ToShortDateString()} |            | {Amount.Value}";
        }
    }
}
