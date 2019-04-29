using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private double Balance;
        private List<Operation> Operations;

        public Account(double amount)
        {
            Operations = new List<Operation>();
            Deposit(amount);
            
        }

        public void Deposit(double amount)
        {
            if(amount < 0)
            {
                throw new Exception("Impossible to make the deposit : negative amount");
            }
            if (amount > 0)
            {
                Balance += amount;
                Operation deposit = new Deposit(amount, DateTime.Now);
                Operations.Add(deposit);

            }

        }

        public double Withdrawal(double amount)
        {
            if(amount < 0)
            {
                throw new Exception("Impossible to make the withdrawal : negative amount");
            }

            if(!HasSuffisantFund(amount))
            {
                throw new Exception("Impossible to make the withdrawal : fund is insuffisant");
            }

            Balance -= amount;
            Operation withdrawal = new Withdrawal(amount, DateTime.Now);
            Operations.Add(withdrawal);
            return amount;
        }

        public double GetBalanceValue()
        {
            return Balance;
        }

        public string GetOperationsHistory(DateTime? startDate, DateTime? endDate)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string dateFrom = string.Empty;
            string dateTo = string.Empty;
            if( startDate.HasValue)
            {
                if (endDate.HasValue)
                {
                    dateFrom = "from " + startDate.Value.Date;
                    dateTo = "to " + endDate.Value.Date;
                }
                else
                {
                    dateFrom = "since " + startDate.Value.Date;
                }
                
            }
            stringBuilder.AppendLine(
                String.Format("Record of the account's operations {0} {1}"
                , dateFrom, dateTo));

            stringBuilder.AppendLine("TYPE       | DATE       | WITHDRAWAL | DEPOSIT");

            Operations.OrderByDescending(b => b.Date)
                .Where(b => (startDate.HasValue ? b.Date >= startDate : true)
                && (endDate.HasValue ? b.Date <= endDate : true))
                .ToList()
                .ForEach(b => stringBuilder.AppendLine(b.ToString()));
            stringBuilder.AppendLine("----------------------------------------------");

            stringBuilder.AppendLine(string.Format("Total of operations     | {0}        | {1}",
                computeTotalWithdrawalBetween(startDate, endDate) == 0 ? "     " : computeTotalWithdrawalBetween(startDate, endDate).ToString(),
                computeTotalDepositBetween(startDate, endDate) == 0 ? "" : computeTotalDepositBetween(startDate, endDate).ToString()));

            stringBuilder.AppendLine("----------------------------------------------");

            stringBuilder.AppendLine(string.Format("Balance Account         | {0}        | {1}",
                Balance < 0 ? Balance.ToString() : "   ",
                Balance >= 0 ? Balance.ToString() : ""));
            return stringBuilder.ToString();
        }


        private bool HasSuffisantFund(double amount)
        {
            return Balance >= amount;
        }

        public int GetOperationsCount()
        {
            return Operations.Count;
        }

        public double computeTotalDepositBetween(DateTime? startDate, DateTime? endDate)
        {
            return  Operations.Where(b => b is Deposit
           && (startDate.HasValue ? b.Date >= startDate : true)
                && (endDate.HasValue ? b.Date <= endDate : true)).Sum(b => b.Amount);
        }

        public double computeTotalWithdrawalBetween(DateTime? startDate, DateTime? endDate)
        {
            return Operations.Where(b => b is Withdrawal
           && (startDate.HasValue ? b.Date >= startDate : true)
                && (endDate.HasValue ? b.Date <= endDate : true)).Sum(b => b.Amount);
        }

        public double computeTotalOperationBefore(DateTime? date)
        {
            var totalWithdrawal =  Operations.Where(b => b is Withdrawal
           && (date.HasValue ? b.Date < date.Value.Date : true)).Sum(b => b.Amount);

            var totalDeposit = Operations.Where(b => b is Deposit
          && (date.HasValue ? b.Date < date.Value.Date : true)).Sum(b => b.Amount);

            return totalDeposit - totalWithdrawal;
        }
    }
}
