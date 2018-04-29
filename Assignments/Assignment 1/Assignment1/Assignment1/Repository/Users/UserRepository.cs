using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Validators;

namespace Assignment1.Repository.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByUsernameAndPassword(string username, string password);

        User GetUserById(long id);
    }
}
