using System;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class WithDrawalTest
    {
        [TestMethod]
        public void MakeAPositiveWithDrawalOnAccountShouldDecreaseBalance()
        {
            Account account = new Account(50);

            account.Withdrawal(10);
            Assert.AreEqual(40.0, account.GetBalanceValue());
        }

        [TestMethod]
        public void MakeANegativeWithDrawalOnAccountShouldDoNothing()
        {
            Account account = new Account(50);

            account.Withdrawal(-10);
            Assert.AreEqual(50.0, account.GetBalanceValue());
        }
    }
}
