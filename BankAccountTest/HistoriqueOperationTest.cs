using System;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class HistoriqueOperationTest
    {
        [TestMethod]
        public void CreateAccountWithAmountZeroShouldNotAddOperationInAccountOperations()
        {
            Account account = new Account(new Amount(0));
            
            Assert.AreEqual(0, account.GetOperationsCount());
        }

        [TestMethod]
        public void CreateAccountWithAmountGreaterThanZeroShouldAddOperationInAccountOperations()
        {
            Account account = new Account(new Amount(10));

            Assert.AreEqual(1, account.GetOperationsCount());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the deposit : negative amount")]
        public void CreateAccountWithNegativeAmountShouldThrowException()
        {
            Account account = new Account(new Amount(-10));
        }

        [TestMethod]
        public void CreateAccountAndMakeDepositWithPositiveAmountShouldAddTwoOperations()
        {
            Amount amount = new Amount(10);
            Account account = new Account(amount);
            account.Deposit(new Amount(50));

            Assert.AreEqual(2, account.GetOperationsCount());
        }

        [TestMethod]
        public void CreateAccountAndMakeDepositAndWithdrawalWithPositiveAmountShouldAddThreeOperations()
        {
            Account account = new Account(new Amount(10));
            account.Deposit(new Amount(50));
            account.Withdrawal(new Amount(40));

            Assert.AreEqual(3, account.GetOperationsCount());
        }

    }
}
