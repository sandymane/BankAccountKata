using System;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class DepositTest
    {
        [TestMethod]
        public void TrueShoulldBeTrue()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void MakeAPositiveDepositOnAccountShouldIncreaseBalance()
        {
            Account account = new Account(50);

            account.MakeDeposit(10);
            Assert.AreEqual(60.0, account.GetBalanceValue());
        }

        [TestMethod]
        public void MakeANegativeDepositOnAccountShouldDoNothing()
        {
            Account account = new Account(50);

            account.MakeDeposit(-80);
            Assert.AreEqual(50.0, account.GetBalanceValue());
        }
    }
}
