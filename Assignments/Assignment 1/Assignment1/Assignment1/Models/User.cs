using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class User
    {
        private long id;
        private string name;
        private string username;
        private string password;
        private Role role;

        public string Name
        {
            get
            {
                return GetName();
            }
        }
        public string Username
        {
            get
            {
                return GetUsername();
            }
        }
        public string Role
        {
            get
            {
                return GetRole().GetRole();
            }
        }

        public long GetId()
        {
            return id;
        }

        public void SetId(long Id)
        {
            id = Id;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            name = Name;
        }

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string Username)
        {
            username = Username;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string Password)
        {
            password = Password;
        }

        public Role GetRole()
        {
            return role;
        }

        public void SetRole(Role Roles)
        {
            role = Roles;
        }
    }
}
