using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Repository.Accounts;

namespace Assignment1.Service.Accounts
{
    public class SavingAccountService : IAccountService
    {
        private ISavingAccountRepository savingAccRepo;

        public SavingAccountService(ISavingAccountRepository savingAccRepo)
        {
            this.savingAccRepo = savingAccRepo;
        }

        public bool CreateAccount(Account account)
        {
            SavingAccount acc = (SavingAccount)account;
            return savingAccRepo.Create(acc);
        }

        public bool DeleteAccount(Account account)
        {
            return savingAccRepo.Delete((SavingAccount)account);
        }

        public List<Account> GetAccounts()
        {
            List<SavingAccount> savingAccounts =  savingAccRepo.FindAll();
            List<Account> accounts = new List<Account>();
            foreach(Account acc in savingAccounts)
            {
                accounts.Add(acc);
            }
            return accounts;
        }

        public bool PayBills(Account accountFrom,double amount)
        {
            SavingAccount bill = savingAccRepo.GetAccountById(0);
            return TransferMoney(accountFrom, amount, bill);
        }

        public bool TransferMoney(Account accountFrom, double amount,Account accountTo)
        {
            double beforeMoney = accountFrom.GetAmountMoney();
            double afterMoney = accountTo.GetAmountMoney();
            accountFrom.SetAmountMoney(beforeMoney - amount);
            accountFrom.SetAmountMoney(afterMoney + amount);
            return savingAccRepo.Update((SavingAccount)accountFrom) && savingAccRepo.Update((SavingAccount)accountTo);
        }
    }
}
