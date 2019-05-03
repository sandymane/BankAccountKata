using System;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class WithDrawalTest
    {
        DateTime date = new DateTime(2019, 05, 02);
        [TestMethod]
        public void MakeAPositiveWithDrawalOnAccountShouldDecreaseBalance()
        {
            Account account = new Account( new Amount(50), date);

            account.Withdrawal( new Amount(10), date);
            Assert.AreEqual(40.0, account.GetBalanceValue());
        }

        [TestMethod]
        public void MakeAPositiveWithDrawalOnAccountShouldReturnAmount()
        {
            Account account = new Account( new Amount(50), date);

            Amount withdrawal = account.Withdrawal( new Amount(10), date);
            Assert.AreEqual(10.0, withdrawal.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the withdrawal : negative amount")]
        public void MakeANegativeWithDrawalOnAccountShouldThrowException()
        {
            Account account = new Account( new Amount(50), date);
            account.Withdrawal( new Amount(-10), date);
            
        }

        [TestMethod]
        public void MakeAWithDrawalGreaterThanBalanceShouldPutNegativeBalance()
        {
            Account account = new Account( new Amount(50), date);

            account.Withdrawal( new Amount(100), date);
            Assert.AreEqual(-50, account.GetBalanceValue());
        }
    }
}
