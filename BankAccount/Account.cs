using System;
using System.Collections.Generic;
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

        public Account(Amount amount, DateTime dateTime) : this()
        {
            _operations = new Operations();
            Deposit(amount, dateTime);
            
        }

        public void Deposit(Amount amount, DateTime dateTime)
        {
            if(amount.isNegative())
            {
                throw new Exception("Impossible to make the deposit : negative amount");
            }
            if (amount.isPositive())
            {
                _balance.IncreaseAmount(amount);
                Operation deposit = new Deposit(amount, dateTime);
                _operations.AddOperation(deposit);

            }

        }

        public Amount Withdrawal(Amount amount, DateTime dateTime)
        {
            if(amount.isNegative())
            {
                throw new Exception("Impossible to make the withdrawal : negative amount");
            }

            _balance.DecreaseAmount(amount);
            Operation withdrawal = new Withdrawal(amount, dateTime);
            _operations.AddOperation(withdrawal);
            return amount;
        }

        public double GetBalanceValue()
        {
            return _balance.Value;
        }

        public List<string> GetOperationsHistoryList()
        {
            List<string> operations = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            string dateFrom = string.Empty;
            string dateTo = string.Empty;

            operations.Add($"Record of the account's operations");
            operations.Add("TYPE       | DATE       | WITHDRAWAL | DEPOSIT");

            _operations.GetFormattedOperationsList().ForEach( b => {
                operations.Add(b);
            });

            operations.Add("----------------------------------------------");

            double withdrawValue = GetTotatlOf<Withdrawal>();
            string withdraw = withdrawValue == 0 ? "" : "-" + GetTotatlOf<Withdrawal>().ToString();
            withdraw = withdraw.CompleteWithSpaces(10);

            operations.Add(string.Format("Total of operations     | {0} | {1}",
                withdraw,
                GetTotatlOf<Deposit>() == 0 ? "" : GetTotatlOf<Deposit>().ToString()));

            operations.Add("----------------------------------------------");

            operations.Add(string.Format("Balance of account      | {0}        | {1}",
                _balance.Value < 0 ? _balance.Value.ToString() : "   ",
                _balance.Value >= 0 ? _balance.Value.ToString() : ""));

            return operations;
        }

        public int GetOperationsCount()
        {
            return _operations.GetCount();
        }

        public Operations GetOperations()
        {
            return _operations;
        }

        public double GetTotatlOf<T>() where T : Operation
        {
            return _operations.ComputeTotalOf<T>();
        }

        public int GetOperationsCountOf<T>() where T : Operation
        {
            return _operations.GetCountOf<T>();
        }
    }
}
