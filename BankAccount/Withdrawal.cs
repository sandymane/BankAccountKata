using System;

namespace BankAccount
{
    public class Withdrawal : Operation
    {
        public Withdrawal(Amount amount, DateTime date) : base(amount, date)
        {

        }

        public override string ToString()
        {
            string withdrawValue = $"-{Amount.Value}".CompleteWithSpaces(10);
            return $"WITHDRAWAL | {Date.Date.ToShortDateString()} | {withdrawValue} |";
        }

    }
}
