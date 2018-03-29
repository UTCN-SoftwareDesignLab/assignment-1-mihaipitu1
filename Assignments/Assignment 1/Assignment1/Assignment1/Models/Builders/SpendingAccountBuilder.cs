using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models.Builders
{
    public class SpendingAccountBuilder
    {
        private SpendingAccount spendingAccount;

        public SpendingAccountBuilder()
        {
            spendingAccount = new SpendingAccount();
        }

        public SpendingAccountBuilder SetId(long id)
        {
            spendingAccount.SetId(id);
            return this;
        }

        public SpendingAccountBuilder SetAmountMoney(double amount)
        {
            spendingAccount.SetAmountMoney(amount);
            return this;
        }

        public SpendingAccountBuilder SetCreationDate(DateTime creationDate)
        {
            spendingAccount.SetCreationDate(creationDate);
            return this;
        }

        public SpendingAccountBuilder SetClient(Client client)
        {
            spendingAccount.SetClient(client);
            return this;
        }

        public SpendingAccountBuilder SetFreeTransactions(int freeTr)
        {
            spendingAccount.SetFreeTransactions(freeTr);
            return this;
        }

        public SpendingAccountBuilder SetTransactionFee(double fee)
        {
            spendingAccount.SetTransactionFee(fee);
            return this;
        }

        public SpendingAccountBuilder SetNoTransactions(int noTransactions)
        {
            spendingAccount.SetNoTransactions(noTransactions);
            return this;
        }

        public SpendingAccount Build()
        {
            return spendingAccount;
        }
    }
}
