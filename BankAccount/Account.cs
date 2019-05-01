using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private Amount _balance;
        private List<Operation> _operations;

        public Account()
        {
            _balance = new Amount(0);
        }

        public Account(Amount amount) : this()
        {
            _operations = new List<Operation>();
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
                _operations.Add(deposit);

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
            _operations.Add(withdrawal);
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

            _operations.OrderByDescending(b => b.Date)
                .ToList()
                .ForEach(b => stringBuilder.AppendLine(b.ToString()));

            stringBuilder.AppendLine("----------------------------------------------");

            double withdrawValue = ComputeTotalOf<Withdrawal>();
            string withdraw = withdrawValue == 0 ? "" : "-" + ComputeTotalOf<Withdrawal>().ToString();
            withdraw = withdraw.CompleteWithSpaces(10);
           
            stringBuilder.AppendLine(string.Format("Total of operations     | {0} | {1}",
                withdraw,
                ComputeTotalOf<Deposit>() == 0 ? "" : ComputeTotalOf<Deposit>().ToString()));

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
            return _operations.Count;
        }

        public double ComputeTotalOf<T>() where T : Operation
        {
            return _operations.Where(b => b is T).Sum(b => b.Amount.Value);
        }

    }
}
