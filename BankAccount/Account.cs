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
            if(amount > 0)
            {
                Balance += amount;
                Operation deposit = new Deposit(amount, DateTime.Now);
                Operations.Add(deposit);
            }
        }

        public double Withdrawal(double amount)
        {
            if (amount > 0 && HasSuffisantFund(amount)) 
            {
                Balance -= amount;
                Operation withdrawal = new Withdrawal(amount, DateTime.Now);
                Operations.Add(withdrawal);
                return amount;
            }
            return 0;
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
                    dateFrom = "Du " + startDate.Value.Date;
                    dateTo = "Au " + endDate.Value.Date;
                }
                else
                {
                    dateTo = "Au " + DateTime.Now;
                }
                
            }
            stringBuilder.AppendLine(
                String.Format("Historique des opérations du compte {0} {1}"
                , dateFrom, dateTo));

            Operations.OrderByDescending(b => b.Date)
                .Where(b => startDate.HasValue ? b.Date >= startDate : true
                && endDate.HasValue ? b.Date <= endDate : true)
                .ToList()
                .ForEach(b => stringBuilder.AppendLine(b.ToString()));

            return stringBuilder.ToString();
        }

        private bool HasSuffisantFund(double amount)
        {
            return Balance >= amount;
        }

    }
}
