using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using MySql.Data.MySqlClient;

namespace Assignment1.Repository.Clients
{
    public class ClientRepositoryMySQL : IClientRepository
    {
        private DBConnectionWrapper connectionWrapper;

        public ClientRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }
        public List<Client> FindAll()
        {
            List<Client> clients = new List<Client>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from client");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clients.Add(GetClientFromReader(reader));
                    }
                }
                connection.Close();
            }
            return clients;
        }

        public Client GetClientById(long id)
        {
            Client client = null;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from client where id = {0}",id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        client = GetClientFromReader(reader);
                    }
                }
                connection.Close();
            }
            return client;
        }

        public bool Create(Client client)
        {
            if (client == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into client (id,name,address) values('{0}','{1}','{2}');", client.GetId(), client.GetName(), client.GetAddress());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Update(Client client)
        {if (client == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    //Debug.WriteLine("This is the client: " + client.GetId() + " " + client.GetName() + " " + client.GetAddress());
                    command.CommandText = String.Format("UPDATE client SET name = '{0}' ,address = '{1}' WHERE id = '{2}';",client.GetName(), client.GetAddress(), client.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
            
        }

        public bool Delete(Client client)
        {
            if (client == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("delete from client where id = {0};", client.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        private Client GetClientFromReader(MySqlDataReader reader)
        {
            if (reader == null)
                return null;
            return new ClientBuilder()
                .SetId(reader.GetInt64(0))
                .SetName(reader.GetString(1))
                .SetAddress(reader.GetString(2))
                .Build();
        }
    }
}
