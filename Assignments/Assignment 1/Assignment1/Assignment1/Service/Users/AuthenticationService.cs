using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Validators;

namespace Assignment1.Service.Users
{
    public interface IAuthenticationService
    {
        Notification<User> Login(string username, string password);
    }
}
