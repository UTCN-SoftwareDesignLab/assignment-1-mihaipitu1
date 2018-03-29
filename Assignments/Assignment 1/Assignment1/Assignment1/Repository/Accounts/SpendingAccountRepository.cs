using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repository.Accounts
{
    public interface ISpendingAccountRepository : BaseRepository<SpendingAccount>
    {
        SpendingAccount GetAccountById(long id);
    }
}
