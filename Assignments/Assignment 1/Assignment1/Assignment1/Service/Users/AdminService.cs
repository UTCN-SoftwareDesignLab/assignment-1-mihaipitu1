using Assignment1.Models;
using Assignment1.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Service.Users
{
    public interface IAdminService
    {
        Notification<bool> Register(string name, string username, string password, Role role);

        bool UpdateUser(User oldUser,string name, string username, string password);

        bool DeleteUser(User user);

        List<User> GetUsers();

        User GetUserById(long id);
    }
}
