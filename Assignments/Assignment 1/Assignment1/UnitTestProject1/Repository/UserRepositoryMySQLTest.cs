using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Repository.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Tests.Repository
{
    [TestClass]
    public class UserRepositoryMySQLTest
    {
        private IUserRepository userRepo;

        public UserRepositoryMySQLTest()
        {
            userRepo = new UserRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true));
        }

        public void RemoveAll()
        {
            List<User> users = userRepo.FindAll();

            foreach (var user in users)
            {
                userRepo.Delete(user);

            }
        }

        [TestMethod]
        public void TestFindAllUsers()
        {
            RemoveAll();
            List<User> users = userRepo.FindAll();
            Assert.AreEqual(users.Count, 0);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            Assert.IsTrue(userRepo.Create(user));
            RemoveAll();
        }

        [TestMethod]
        public void TestEditUser()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            userRepo.Create(user);
            Assert.IsTrue(userRepo.Update(user));
            RemoveAll();
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            userRepo.Create(user);
            Assert.IsTrue(userRepo.Delete(user));
            RemoveAll();
        }

        [TestMethod]
        public void TestFindUserById()
        {
            User user = userRepo.GetUserById(0);
            Assert.IsNull(user.GetName());
        }

        [TestMethod]
        public void TestFindUserByUsernameAndPassword()
        {
            User user = userRepo.GetUserByUsernameAndPassword("user", "pass");
            Assert.IsNull(user.GetName());
        }

        [TestMethod]
        public void TestFindAllUsersNotNull()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            userRepo.Create(user);
            user.SetId(user.GetId() + 1);
            userRepo.Create(user);
            user.SetId(user.GetId() + 1);
            userRepo.Create(user);
            List<User> users = userRepo.FindAll();
            Assert.AreEqual(users.Count, 3);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindUserByIdNotNull()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            userRepo.Create(user);
            User users = userRepo.GetUserById(1);
            Assert.IsNotNull(users);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindUserByUsernameAndPasswordNotNull()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            userRepo.Create(user);
            User users = userRepo.GetUserByUsernameAndPassword("User", "Password");
            Assert.IsNotNull(users);
            RemoveAll();
        }
    }
}
