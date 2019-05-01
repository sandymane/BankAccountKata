using System;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class DepositTest
    {
       

        [TestMethod]
        public void MakeAPositiveDepositOnAccountShouldIncreaseBalance()
        {
            Account account = new Account(new Amount(50));

            account.Deposit(new Amount(10));
            Assert.AreEqual(60.0, account.GetBalanceValue());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the deposit : negative amount")]
        public void MakeANegativeDepositOnAccountShouldThrowException()
        {
            Account account = new Account(new Amount(50));
            account.Deposit(new Amount(-80));
        }
    }
}
