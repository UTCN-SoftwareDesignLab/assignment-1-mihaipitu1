using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using MySql.Data.MySqlClient;

namespace Assignment1.Repository.Accounts
{
    public class AccountRepositoryMySQL : IAccountRepository
    {
        private DBConnectionWrapper connectionWrapper;

        public AccountRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public bool Create(Account t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into account (id,type,amountMoney,creationDate,clientId) VALUES('{0}','{1}','{2}','{3}','{4}');",t.GetId(),t.GetType(),t.GetAmountMoney(),t.GetCreationDate(),t.GetClientId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Delete(Account t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Delete from account where id = '{0}' ;", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<Account> FindAll()
        {
            List<Account> accounts = new List<Account>();

            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from account");
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

        public Account GetAccountById(long id)
        {
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from account where id = {0}", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return GetAccountFromReader(reader);
                    }
                }
                connection.Close();
            }
            return null;
        }

        public bool Update(Account t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("UPDATE account SET amountMoney = '{0}' WHERE id = '{1}';", t.GetAmountMoney(),t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        private Account GetAccountFromReader(MySqlDataReader reader)
        {
            return new AccountBuilder()
                .SetId(reader.GetInt64(0))
                .SetType(reader.GetString(1))
                .SetAmountMoney(reader.GetDouble(2))
                .SetCreationDate(reader.GetDateTime(3))
                .SetClientId(reader.GetInt64(4))
                .Build();
        }
    }
}
