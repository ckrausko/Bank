using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankProblem
{
    public abstract class AbstractAccount
    {
        public string Owner { get; protected set; }
        public decimal Balance { get; protected set; }
        public AbstractAccount(string owner, decimal balance)
        {
            Owner = owner;
            Balance = balance;
        }

        /// <summary>
        /// Deposit money into bank account
        /// </summary>
        /// <param name="depositAmount">Amount of money to deposit into account</param>
        /// <returns></returns>
        public decimal Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
            return Balance;
        }
        /// <summary>
        /// Withdrawl money from bank account
        /// </summary>
        /// <param name="withdrawlAmount">Amount of money to withdrawl from account</param>
        /// <returns></returns>
        public decimal Withdrawl(decimal withdrawlAmount)
        {
            if (SufficientFunds(withdrawlAmount)){
                Balance -= withdrawlAmount;
            }
            return Balance;
        }
        /// <summary>
        /// Transfer money from one account to another
        /// </summary>
        /// <param name="transferAmount">Amount of money to transfer</param>
        /// <param name="account">Account to transfer money into</param>
        /// <returns></returns>
        public decimal Transfer(decimal transferAmount, AbstractAccount account)
        {
            if (SufficientFunds(transferAmount))
            {
                Withdrawl(transferAmount);
                account.Deposit(transferAmount);
            }
            return Balance;
        }
        /// <summary>
        /// Check if there is enough money in the account
        /// </summary>
        /// <param name="amount">Amount of money to check for</param>
        /// <returns></returns>
        public bool SufficientFunds(decimal amount)
        {
            if(amount <= Balance)
            {
                return true;
            }
            return false;
        }

    }
    public class CheckingAccount : AbstractAccount
    {
        public CheckingAccount(string owner, decimal balance) : base(owner, balance)
        {
        }
    }
    public class CorporateInvestmentAccount : AbstractAccount
    {
        public CorporateInvestmentAccount(string owner, decimal balance) : base(owner, balance)
        {
        }
    }
    public class IndividualInvestmentAccount : AbstractAccount
    {
        public IndividualInvestmentAccount(string owner, decimal balance) : base(owner, balance)
        {
        }

        public new decimal Withdrawl(decimal withdrawlAmount)
        {
            if (SufficientFunds(withdrawlAmount))
            {
                if(withdrawlAmount > 1000m)
                {
                    withdrawlAmount = 1000m;
                }
                Balance -= withdrawlAmount;
            }
            return Balance;
        }
    }

}
