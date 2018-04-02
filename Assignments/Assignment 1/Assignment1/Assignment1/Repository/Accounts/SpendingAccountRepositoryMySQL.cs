using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Repository.Clients;
using MySql.Data.MySqlClient;

namespace Assignment1.Repository.Accounts
{
    public class SpendingAccountRepositoryMySQL : ISpendingAccountRepository
    {
        private DBConnectionWrapper connectionWrapper;
        private ClientRepositoryMySQL clientRepo;
        public SpendingAccountRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
            clientRepo = new ClientRepositoryMySQL(connectionWrapper);
        }

        public bool Create(SpendingAccount t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into account ({0},'spending',{1},{2},{3})",t.GetId(),t.GetAmountMoney(),t.GetCreationDate(),t.GetClient().GetId());
                    command.ExecuteNonQuery();
                    command.CommandText = String.Format("Insert into spendingaccount ({0},{1},{2},{3})",t.GetId(),t.GetFreeTransactions(),t.GetTransactionFee(),t.GetNoTransactions());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Update(SpendingAccount t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Update account SET amountMoney = {1} where id = {0}", t.GetId(), t.GetAmountMoney());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<SpendingAccount> FindAll()
        {
            List<SpendingAccount> accounts = new List<SpendingAccount>();

            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT bank.account.id,bank.account.amountMoney,bank.account.creationDate,bank.spendingaccount.freeTransactions,bank.spendingaccount.transactionFee,bank.spendingaccount.noTransactions FROM bank.account join bank.spendingaccount on account.id = bank.spendingaccount.id");
                    MySqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        accounts.Add(GetAccountFromReader(reader));
                    }
                }
                connection.Close();
            }

            return accounts;
        }

        public SpendingAccount GetAccountById(long id)
        {
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT ac.id, ac.amountMoney, ac.creationDate, ac.clientId, sp.FreeTransactions, sp.TransactionsFee, sp.NoTransactions" +
                        "FROM account ac INNER JOIN spendingaccount sp ON ac.id = sp.id WHERE id = {0}",id);
                    MySqlDataReader reader = command.ExecuteReader();
                    return GetAccountFromReader(reader);
                }
                connection.Close();
            }
        }

        public bool Delete(SpendingAccount t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("delete from account where id = {0}", t.GetId());
                    command.ExecuteNonQuery();
                    command.CommandText = String.Format("delete from spendingaccount where id = {0}", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        private SpendingAccount GetAccountFromReader(MySqlDataReader reader)
        {
            return new SpendingAccountBuilder()
                .SetId(reader.GetInt64(0))
                .SetAmountMoney(reader.GetDouble(1))
                .SetCreationDate(reader.GetDateTime(2))
                .SetClient(clientRepo.GetClientById(reader.GetInt64(0)))
                .SetFreeTransactions(reader.GetInt32(4))
                .SetTransactionFee(reader.GetDouble(5))
                .SetNoTransactions(reader.GetInt32(6))
                .Build();
        }
    }
}
