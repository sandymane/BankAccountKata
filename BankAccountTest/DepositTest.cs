using System;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class DepositTest
    {
        DateTime date = new DateTime(2019, 05, 02);

        [TestMethod]
        public void MakeAPositiveDepositOnAccountShouldIncreaseBalance()
        {
            Account account = new Account(new Amount(50), date);

            account.Deposit(new Amount(10), date);
            Assert.AreEqual(60.0, account.GetBalanceValue());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the deposit : negative amount")]
        public void MakeANegativeDepositOnAccountShouldThrowException()
        {
            Account account = new Account(new Amount(50), date);
            account.Deposit(new Amount(-80), date);
        }
    }
}
