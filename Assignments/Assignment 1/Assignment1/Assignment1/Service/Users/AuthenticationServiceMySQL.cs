using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Assignment1.Repository.Users;
using Assignment1.Models;
using Assignment1.Models.Validators;
using Assignment1.Models.Builders;

namespace Assignment1.Service.Users
{
    public class AuthenticationServiceMySQL : IAuthenticationService
    {
        private IUserRepository userRepo;

        public AuthenticationServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public Notification<User> Login(string username, string password)
        {
            return userRepo.GetUserByUsernameAndPassword(username, EncodePassword(password));
        }

        private string EncodePassword(string password)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(password);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            foreach (byte b in cryString)
            {
                sha256Str += cryString.ToString();
            }
            return sha256Str;
        }


    }
}
