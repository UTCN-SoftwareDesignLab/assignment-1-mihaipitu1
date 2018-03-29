using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Models.Validators;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repository.Users
{
    public class UserRepositoryMySQL : IUserRepository
    {
        private DBConnectionWrapper connectionWrapper;

        public UserRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public bool Delete(User user)
        {
            if (user == null)
                return false;
            if (!user.Equals(GetUserById(user.GetId())))
                return false; 
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("delete from user where id = {0}", user.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<User> FindAll()
        {
            List<User> users = new List<User>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from user");
                    MySqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        users.Add(GetUserFromReader(reader));
                    }
                }
                connection.Close();
            }
            return users;
        }

        public User GetUserById(long id)
        {
            User user = new User();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from user where id = {0}", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    user = GetUserFromReader(reader);
                }
                connection.Close();
            }
            return user;
        }

        public Notification<User> GetUserByUsernameAndPassword(string username, string password)
        {
            Notification<User> notifier = new Notification<User>();
            User user = new User();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from user where username = '{0}' and password = '{1}' ",username,password);
                    MySqlDataReader reader = command.ExecuteReader();
                    user = GetUserFromReader(reader);
                    notifier.SetResult(user);
                }
                connection.Close();
            }
            return notifier;
        }

        public bool Create(User user)
        {
            if (user == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Insert into user({0},{1},{2},{3})", user.GetId(),user.GetName(),user.GetUsername(),user.GetPassword());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Update(User user)
        {
            if (GetUserById(user.GetId()) == null)
                return false;
            else
            {
                Delete(user);
                Create(user);
                return true;
            }

        }

        private User GetUserFromReader(MySqlDataReader reader)
        {
            Role role = new Role(null, null);
            if (reader.GetBoolean(4) == true)
            {
                role = GetRoleFromRights(Constants.Roles.ADMIN);
            }
            else
            {
                role = GetRoleFromRights(Constants.Roles.EMPLOYEE);
            }
            return new UserBuilder()
                .SetId(reader.GetInt64(0))
                .SetName(reader.GetString(1))
                .SetUsername(reader.GetString(2))
                .SetPassword(reader.GetString(3))
                .SetRole(role)
                .Build(); 
        }

        private Role GetRoleFromRights(string role)
        {
            List<Right> rights = new List<Right>();
            if (role == Constants.Roles.ADMIN)
            {
                foreach (var right in Constants.Rights.ADMIN_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            else
            {
                foreach (var right in Constants.Rights.USER_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            return new Role(role, rights);
        }
    }
}
