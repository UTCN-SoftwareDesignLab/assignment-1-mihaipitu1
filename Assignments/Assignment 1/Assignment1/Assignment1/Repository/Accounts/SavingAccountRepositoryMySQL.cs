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
    public class SavingAccountRepositoryMySQL : ISavingAccountRepository
    {
        private DBConnectionWrapper connectionWrapper;
        private ClientRepositoryMySQL clientRepo;

        public SavingAccountRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
            clientRepo = new ClientRepositoryMySQL(connectionWrapper);
        }
        public bool Create(SavingAccount t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into account ({0},'saving',{1},{2},{3})", t.GetId(), t.GetAmountMoney(), t.GetCreationDate(), t.GetClient().GetId());
                    command.ExecuteNonQuery();
                    command.CommandText = String.Format("Insert into savingaccount ({0},{1},{2})", t.GetId(), t.GetInterestRate(), t.GetMinAmount());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Update(SavingAccount t)
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

        public List<SavingAccount> FindAll()
        {
            List<SavingAccount> accounts = new List<SavingAccount>();

            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT ac.id, ac.amountMoney, ac.creationDate, ac.clientId, sp.interestRate, sp.minAmount" +
                        "FROM account ac INNER JOIN savingaccount sp ON ac.id = sp.id");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        accounts.Add(GetAccountFromReader(reader));
                    }
                }
                connection.Close();
            }

            return accounts;
        }

        public SavingAccount GetAccountById(long id)
        {
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT ac.id, ac.amountMoney, ac.creationDate, ac.clientId, sp.FreeTransactions, sp.TransactionsFee, sp.NoTransactions" +
                        "FROM account ac INNER JOIN SavingAccount sp ON ac.id = sp.id WHERE id = {0}", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    return GetAccountFromReader(reader);
                }
                connection.Close();
            }
        }

        public bool Delete(SavingAccount t)
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
                    command.CommandText = String.Format("delete from savingaccount where id = {0}", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        private SavingAccount GetAccountFromReader(MySqlDataReader reader)
        {
            return new SavingAccountBuilder()
                .SetId(reader.GetInt64(0))
                .SetAmountMoney(reader.GetDouble(1))
                .SetCreationDate(reader.GetDateTime(2))
                .SetClient(clientRepo.GetClientById(reader.GetInt64(3)))
                .SetInterestRate(reader.GetDouble(4))
                .SetMinAmount(reader.GetDouble(5))
                .Build();
        }
    }
}
