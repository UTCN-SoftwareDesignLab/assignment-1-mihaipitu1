using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models.Builders
{
    public class SavingAccountBuilder
    {
        private SavingAccount savingAccount;

        public SavingAccountBuilder()
        {
            savingAccount = new SavingAccount();
        }

        public SavingAccountBuilder SetId(long id)
        {
            savingAccount.SetId(id);
            return this;
        }

        public SavingAccountBuilder SetAmountMoney(double amount)
        {
            savingAccount.SetAmountMoney(amount);
            return this;
        }

        public SavingAccountBuilder SetCreationDate(DateTime creationDate)
        {
            savingAccount.SetCreationDate(creationDate);
            return this;
        }

        public SavingAccountBuilder SetClient(Client client)
        {
            savingAccount.SetClient(client);
            return this;
        }

        public SavingAccountBuilder SetInterestRate(double interest)
        {
            savingAccount.SetInterestRate(interest);
            return this;
        }

        public SavingAccountBuilder SetMinAmount(double minAmount)
        {
            savingAccount.SetMinAmount(minAmount);
            return this;
        }

        public SavingAccount Build()
        {
            return savingAccount;
        }
    }
}
