using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Models.Validators;
using Assignment1.Repository.Users;

namespace Assignment1.Service.Users
{
    public class AdminServiceMySQL : IAdminService
    {
        private IUserRepository userRepo;

        public AdminServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;  
        }

        public bool DeleteUser(User user)
        {
            return userRepo.Delete(user);
        }

        public List<User> GetUsers()
        {
            return userRepo.FindAll();
        }

        public Notification<bool> Register(string name, string username, string password, Role role)
        {
            User user = new UserBuilder()
                .SetId(GetMaxId()+1)
                .SetName(name)
                .SetUsername(username)
                .SetPassword(password)
                .SetRole(role)
                .Build();
            UserValidator userValidator = new UserValidator(user);
            bool userValid = userValidator.Validate();
            Notification<bool> notifier = new Notification<bool>();

            if (!userValid)
            {
                foreach (var error in userValidator.GetErrors())
                {
                    notifier.AddError(error);
                }
                notifier.SetResult(false);
            }
            else
            {
                user.SetPassword(EncodePassword(password));
                notifier.SetResult(userRepo.Create(user));
            }
            return notifier;

        }

        public User GetUserById(long id)
        {
            return userRepo.GetUserById(id);
        }

        private string EncodePassword(string password)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(password);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            foreach (byte b in cryString)
            {
                sha256Str += b.ToString("x");
   
            }
            return sha256Str;
        }

        private long GetMaxId()
        {
            List<User> users = userRepo.FindAll();
            if (users.Capacity == 0)
                return 1;
            else
            {
                long max = users.ElementAt(0).GetId();
                foreach (User user in users)
                {
                    if (max < user.GetId())
                        max = user.GetId();
                }
                return max;
            }
        }


        public bool UpdateUser(User oldUser,string name, string username, string password)
        {
            User user = new UserBuilder()
                .SetId(oldUser.GetId())
                .SetName(name)
                .SetUsername(username)
                .SetPassword(password)
                .SetRole(oldUser.GetRole())
                .Build();
            return userRepo.Update(user);
        }
    }
}
