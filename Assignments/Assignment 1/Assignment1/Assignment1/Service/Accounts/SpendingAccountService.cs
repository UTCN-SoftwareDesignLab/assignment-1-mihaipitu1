using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Repository.Accounts;

namespace Assignment1.Service.Accounts
{
    public class SpendingAccountService : IAccountService
    {
        private ISpendingAccountRepository spendingAccRepo;

        public SpendingAccountService(ISpendingAccountRepository spendingAccRepo)
        {
            this.spendingAccRepo = spendingAccRepo;
        }

        public List<Account> GetAccounts()
        {
            List<SpendingAccount> spendingAccounts =  spendingAccRepo.FindAll();
            List<Account> accounts = new List<Account>();
            foreach(Account acc in spendingAccounts)
            {
                accounts.Add(acc);
            }
            return accounts;
        }

        public bool CreateAccount(Account account)
        {
            return spendingAccRepo.Create((SpendingAccount)account);
        }

        public bool DeleteAccount(Account account)
        {
            return spendingAccRepo.Delete((SpendingAccount)account);
        }

        public bool PayBills(Account accountFrom, double amount)
        {
            SpendingAccount bill = spendingAccRepo.GetAccountById(0);
            return TransferMoney(accountFrom, amount, bill);
        }

        public bool TransferMoney(Account accountFrom, double amount, Account accountTo)
        {
            double beforeMoney = accountFrom.GetAmountMoney();
            double afterMoney = accountTo.GetAmountMoney();
            accountFrom.SetAmountMoney(beforeMoney - amount);
            accountFrom.SetAmountMoney(afterMoney + amount);
            return spendingAccRepo.Update((SpendingAccount)accountFrom) && spendingAccRepo.Update((SpendingAccount)accountTo);
        }
    }
}
