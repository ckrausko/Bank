using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankProblem;
using System.Collections.Generic;

namespace BankUnitTest
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Withdrawl_Return0_IfbalanceIs0()
        {
            var account = new CheckingAccount("owner", 0);
            var balance = account.Withdrawl(10);

            Assert.AreEqual(0, balance);
        }
        [TestMethod]
        public void Withdrawl_Return1_IfbalanceIs10AndAmountIs9()
        {
            var account = new CheckingAccount("owner", 10);
            var balance = account.Withdrawl(9);

            Assert.AreEqual(1, balance);
        }
        [TestMethod]
        public void Withdrawl_ReturnSameBalance_IfbalanceIsLessThanWithdrawlAmount()
        {
            var account = new CheckingAccount("owner", 10);
            var balance = account.Withdrawl(11);

            Assert.AreEqual(10, balance);
        }
        [TestMethod]
        public void Withdrawl_Return0_IfbalanceIs10AndWithdrawlAmountIs10()
        {
            var account = new CheckingAccount("owner", 10);
            var balance = account.Withdrawl(10);

            Assert.AreEqual(0, balance);
        }
        [TestMethod]
        public void Withdrawl_Return10_IfAmountIsGreaterThan1000()
        {
            var account = new IndividualInvestmentAccount("owner", 1010);
            var balance = account.Withdrawl(1010);

            Assert.AreEqual(10, balance);
        }
        [TestMethod]
        public void Deposit_Return10_IfBalanceIs0AndDepositAmountIs10()
        {
            var account = new IndividualInvestmentAccount("owner", 0);
            var balance = account.Deposit(10);

            Assert.AreEqual(10, balance);
        }
        [TestMethod]
        public void Deposit_Return0_IfBalanceIs0AndDepositAmountIs0()
        {
            var account = new IndividualInvestmentAccount("owner", 0);
            var balance = account.Deposit(0);

            Assert.AreEqual(0, balance);
        }
        [TestMethod]
        public void Transfer_ReturnBalances()
        {
            var account = new IndividualInvestmentAccount("owner", 10);
            var account2 = new IndividualInvestmentAccount("owner", 10);
            
            var account1Balance = account.Transfer(10, account2);

            Assert.AreEqual(0, account1Balance);
            Assert.AreEqual(20, account2.Balance);
        }

    }
}
