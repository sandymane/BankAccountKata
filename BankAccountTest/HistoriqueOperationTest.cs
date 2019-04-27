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
            Account account = new Account(0);
            
            Assert.AreEqual(0, account.GetOperationsCount());
        }

        [TestMethod]
        public void CreateAccountWithAmountGreaterThanZeroShouldAddOperationInAccountOperations()
        {
            Account account = new Account(10);

            Assert.AreEqual(1, account.GetOperationsCount());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Impossible to make the deposit : negative amount")]
        public void CreateAccountWithNegativeAmountShouldThrowException()
        {
            Account account = new Account(-10);

        }

        [TestMethod]
        public void CreateAccountAndMakeDepositWithPositiveAmountShouldAddTwoOperations()
        {
            Account account = new Account(10);
            account.Deposit(50);

            Assert.AreEqual(2, account.GetOperationsCount());
        }

        [TestMethod]
        public void CreateAccountAndMakeDepositAndWithdrawalWithPositiveAmountShouldAddThreeOperations()
        {
            Account account = new Account(10);
            account.Deposit(50);
            account.Withdrawal(40);

            Assert.AreEqual(3, account.GetOperationsCount());
        }

//        [TestMethod]
//        public void CreateAccountAndMake2DepositsAnd1WithdrawalShouldGiveHistoriqueOfFourOperations()
//        {
//            Account account = new Account(10);
//            account.Deposit(50);
//            account.Deposit(80);
//            account.Withdrawal(100.5);

//            string historique = @"Record of the account's operations  
//TYPE | DATE | AMOUNT | BALANCE
//DEPOSIT | 27/04/2019 | 18:22 | 10 | 10
//DEPOSIT | 27/04/2019 | 18:22 | 50 | 50
//DEPOSIT | 27/04/2019 | 18:22 | 80 | 80
//WITHDRAWAL | 27/04/2019 | 18:22 | 100,5 |-100,5  
//";
//            Assert.AreEqual(historique, account.GetOperationsHistory(null, null));
//        }
    }
}
