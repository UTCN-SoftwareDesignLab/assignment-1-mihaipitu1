using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Repository.Accounts;

namespace Assignment1.Service.Accounts
{
    public class AccountServiceMySQL : IAccountService
    {
        IAccountRepository accountRepo;

        public AccountServiceMySQL(IAccountRepository accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        public bool CreateAccount(Account account)
        {
            return accountRepo.Create(account);
        }

        public bool DeleteAccount(Account account)
        {
            return accountRepo.Delete(account);
        }

        public List<Account> GetAccounts()
        {
            return accountRepo.FindAll();
        }

        public bool PayBills(Account accountFrom, double amount)
        {
            double newAmount = accountFrom.GetAmountMoney() - amount;
            Debug.WriteLine(newAmount);
            accountFrom.SetAmountMoney(newAmount);
            return accountRepo.Update(accountFrom);
        }

        public bool TransferMoney(Account accountFrom, double amount, Account accountTo)
        {
            accountFrom.SetAmountMoney(accountFrom.GetAmountMoney() - amount);
            accountTo.SetAmountMoney(accountTo.GetAmountMoney() + amount);
            return accountRepo.Update(accountFrom) && accountRepo.Update(accountTo);
        }

        public Account GetAccountById(long id)
        {
            return accountRepo.GetAccountById(id);
        }

        public long GetMaxId()
        {
            List<Account> accounts = GetAccounts();
            long id = -1;
            foreach(var acc in accounts)
            {
                if (acc.GetId() > id)
                    id = acc.GetId();
            }
            return id;

        }
    }
}
