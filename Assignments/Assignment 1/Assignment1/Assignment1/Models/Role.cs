using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Role
    {
        private string role;
        private List<Right> rights;

        public Role(string role,List<Right> rights)
        {
            this.role = role;
            this.rights = rights;
        }

        public string GetRole()
        {
            return role;
        }

        public void SetRole(string role)
        {
            this.role = role;
        }

        public List<Right> GetRights()
        {
            return rights;
        }

        public void SetRights(List<Right> rights)
        {
            this.rights = rights;
        }
    }
}
