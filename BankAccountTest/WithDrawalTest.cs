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
            Account account = new Account( new Amount(50));

            account.Withdrawal( new Amount(10));
            Assert.AreEqual(40.0, account.GetBalanceValue());
        }

        [TestMethod]
        public void MakeAPositiveWithDrawalOnAccountShouldReturnAmount()
        {
            Account account = new Account( new Amount(50));

            Amount withdrawal = account.Withdrawal( new Amount(10));
            Assert.AreEqual(10.0, withdrawal.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the withdrawal : negative amount")]
        public void MakeANegativeWithDrawalOnAccountShouldThrowException()
        {
            Account account = new Account( new Amount(50));
            account.Withdrawal( new Amount(-10));
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the withdrawal : fund is insuffisant")]
        public void MakeAWithDrawalGreaterThanBalanceShouldThrowException()
        {
            Account account = new Account( new Amount(50));

            account.Withdrawal( new Amount(100));
        }
    }
}
