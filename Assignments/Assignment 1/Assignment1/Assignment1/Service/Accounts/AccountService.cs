using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Service.Accounts
{
    public interface IAccountService
    {
        List<Account> GetAccounts();

        bool CreateAccount(Account account);

        bool TransferMoney(Account accountFrom, double amount,Account accountTo);

        bool DeleteAccount(Account account);

        bool PayBills(Account accountFrom,double amount);

        Account GetAccountById(long id);

        long GetMaxId();
    }
}
