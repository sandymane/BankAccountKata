using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Client
    {
        List<Account> Accounts;

        public Client()
        {
            Accounts = new List<Account>();
        }

        public void MakeDeposit(Account account, double amount)
        {
            account.Deposit(amount);
        }
    }
}
