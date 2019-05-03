using System;
using System.Text;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class HistoriqueOperationTest
    {
        DateTime date = new DateTime(2019, 05, 02);
        [TestMethod]
        public void CreateAccountWithAmountZeroShouldNotAddOperationInAccountOperations()
        {
            Account account = new Account(new Amount(0), date);
            
            Assert.AreEqual(0, account.GetOperationsCount());
        }

        [TestMethod]
        public void CreateAccountWithAmountGreaterThanZeroShouldAddOperationInAccountOperations()
        {
            Account account = new Account(new Amount(10), date);

            Assert.AreEqual(1, account.GetOperationsCount());
        }

    
        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the deposit : negative amount")]
        public void CreateAccountWithNegativeAmountShouldThrowException()
        {
            Account account = new Account(new Amount(-10), date);
        }

        [TestMethod]
        public void CreateAccountAndMakeDepositWithPositiveAmountShouldAddTwoOperations()
        {
            Amount amount = new Amount(10);
            Account account = new Account(amount, date);
            account.Deposit(new Amount(50), date);

            Assert.AreEqual(2, account.GetOperationsCount());
            Assert.AreEqual(2, account.GetOperationsCountOf<Deposit>());
        }

        [TestMethod]
        public void CreateAccountAndMakeDepositAndWithdrawalWithPositiveAmountShouldAddThreeOperations()
        {
            Account account = new Account(new Amount(10), date);
            account.Deposit(new Amount(50), date);
            account.Withdrawal(new Amount(40), date);

            Assert.AreEqual(3, account.GetOperationsCount());
            Assert.AreEqual(2, account.GetOperationsCountOf<Deposit>());
            Assert.AreEqual(1, account.GetOperationsCountOf<Withdrawal>());
        }

    }
}
