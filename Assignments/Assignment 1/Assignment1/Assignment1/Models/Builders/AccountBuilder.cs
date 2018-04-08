using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models.Builders
{
    public class AccountBuilder
    {
        private Account account;

        public AccountBuilder()
        {
            account = new Account();
        }

        public AccountBuilder SetId(long id)
        {
            account.SetId(id);
            return this;
        }

        public AccountBuilder SetAmountMoney(double amountMoney)
        {
            account.SetAmountMoney(amountMoney);
            return this;
        }

        public AccountBuilder SetType(string type)
        {
            account.SetType(type);
            return this;
        }

        public AccountBuilder SetCreationDate(DateTime creationDate)
        {
            account.SetCreationDate(creationDate);
            return this;
        }

        public AccountBuilder SetClientId(long clientId)
        {
            account.SetClientId(clientId);
            return this;
        }

        public Account Build()
        {
            return account;
        }
    }
}
