using System;
using System.Text;

namespace BankAccount
{
    public class Account
    {
        private Amount _balance;
        private Operations _operations;

        public Account()
        {
            _balance = new Amount(0);
        }

        public Account(Amount amount) : this()
        {
            _operations = new Operations();
            Deposit(amount);
            
        }

        public void Deposit(Amount amount)
        {
            if(amount.isNegative())
            {
                throw new Exception("Impossible to make the deposit : negative amount");
            }
            if (amount.isPositive())
            {
                _balance.Add(amount);
                Operation deposit = new Deposit(amount, DateTime.Now);
                _operations.AddOperation(deposit);

            }

        }

        public Amount Withdrawal(Amount amount)
        {
            if(amount.isNegative())
            {
                throw new Exception("Impossible to make the withdrawal : negative amount");
            }

            if (!HasSuffisantFundToSubstract(amount))
            {
                throw new Exception("Impossible to make the withdrawal : fund is insuffisant");
            }

            _balance.Substract(amount);
            Operation withdrawal = new Withdrawal(amount, DateTime.Now);
            _operations.AddOperation(withdrawal);
            return amount;
        }

        public double GetBalanceValue()
        {
            return _balance.Value;
        }

        public string GetOperationsHistory()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string dateFrom = string.Empty;
            string dateTo = string.Empty;
      
            stringBuilder.AppendLine( $"Record of the account's operations");
            stringBuilder.AppendLine("TYPE       | DATE       | WITHDRAWAL | DEPOSIT");

            stringBuilder.AppendLine(_operations.ToString());

            stringBuilder.AppendLine("----------------------------------------------");

            double withdrawValue = GetTotatlOf<Withdrawal>();
            string withdraw = withdrawValue == 0 ? "" : "-" + GetTotatlOf<Withdrawal>().ToString();
            withdraw = withdraw.CompleteWithSpaces(10);
           
            stringBuilder.AppendLine(string.Format("Total of operations     | {0} | {1}",
                withdraw,
                GetTotatlOf<Deposit>() == 0 ? "" : GetTotatlOf<Deposit>().ToString()));

            stringBuilder.AppendLine("----------------------------------------------");

            stringBuilder.AppendLine(string.Format("Balance of account      | {0}        | {1}",
                _balance.Value < 0 ? "-"+_balance.Value.ToString() : "   ",
                _balance.Value >= 0 ? _balance.Value.ToString() : ""));

            return stringBuilder.ToString();
        }

        private bool HasSuffisantFundToSubstract(Amount amount)
        {
            return _balance.Value >= amount.Value;
        }

        public int GetOperationsCount()
        {
            return _operations.GetCount();
        }

        public double GetTotatlOf<T>() where T : Operation
        {
            return _operations.ComputeTotalOf<T>();
        }

    }
}
