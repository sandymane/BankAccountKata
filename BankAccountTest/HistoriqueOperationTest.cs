using System;
using System.Collections.Generic;
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
        public void CreateAccountAndMakeDepositAndWithdrawalShouldAddThreeOperations()
        {
            Account account = new Account(new Amount(10), date);
            account.Deposit(new Amount(50), date);
            account.Withdrawal(new Amount(40), date);

            Assert.AreEqual(3, account.GetOperationsCount());
            Assert.AreEqual(2, account.GetOperationsCountOf<Deposit>());
            Assert.AreEqual(1, account.GetOperationsCountOf<Withdrawal>());
        }

        [TestMethod]
        public void CreateAccountAndMakeOperationsShouldReturTheCorrectOperationsList()
        {
            Account account = new Account(new Amount(10), new DateTime(2019, 05, 01));
            account.Deposit(new Amount(50), new DateTime(2019, 05, 02));
            account.Withdrawal(new Amount(40), new DateTime(2019, 05, 03));

            List<string> operationsExpected = new List<string>();

            operationsExpected.Add($"Record of the account's operations");
            operationsExpected.Add("TYPE       | DATE       | WITHDRAWAL | DEPOSIT");
            operationsExpected.Add("WITHDRAWAL | 03/05/2019 | -40        |");
            operationsExpected.Add("DEPOSIT    | 02/05/2019 |            | 50");
            operationsExpected.Add("DEPOSIT    | 01/05/2019 |            | 10");
            operationsExpected.Add("----------------------------------------------");
            operationsExpected.Add("Total of operations     | -40        | 60");
            operationsExpected.Add("----------------------------------------------");
            operationsExpected.Add("Balance of account      |            | 20");

            CollectionAssert.AreEqual(operationsExpected, account.GetOperationsHistoryList());
        }

    }
}
