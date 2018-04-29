using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Repository.Accounts;
using Assignment1.Repository.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Tests.Repository
{
    [TestClass]
    public class AccountRepositoryMySQLTest
    {
        private IAccountRepository accRepo;
        private IClientRepository clientRepo;

        public AccountRepositoryMySQLTest()
        {
            accRepo = new AccountRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true));
            clientRepo = new ClientRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true));
        }

        public void RemoveAll()
        {
            List<Account> accounts = accRepo.FindAll();

            foreach (var user in accounts)
            {
                accRepo.Delete(user);

            }

            List<Client> clients = clientRepo.FindAll();
            foreach(var client in clients)
            {
                clientRepo.Delete(client);
            }
        }

        [TestMethod]
        public void TestFindAllAccounts()
        {
            RemoveAll();
            List<Account> users = accRepo.FindAll();
            Assert.AreEqual(users.Count, 0);
        }

        [TestMethod]
        public void TestCreateAccount()
        {
            RemoveAll();
            Client cl = new ClientBuilder()
                .SetId(1)
                .SetName("name")
                .SetAddress("address")
                .Build();
            clientRepo.Create(cl);
            Account acc = new AccountBuilder()
                .SetId(1)
                .SetType("spending")
                .SetAmountMoney(1.0)
                .SetCreationDate(DateTime.Now)
                .SetClientId(1)
                .Build();
            Assert.IsTrue(accRepo.Create(acc));
            RemoveAll();
        }

        [TestMethod]
        public void TestUpdateAccount()
        {
            RemoveAll();
            Client cl = new ClientBuilder()
                .SetId(1)
                .SetName("name")
                .SetAddress("address")
                .Build();
            clientRepo.Create(cl);
            Account acc = new AccountBuilder()
                .SetId(1)
                .SetType("spending")
                .SetAmountMoney(1.0)
                .SetCreationDate(DateTime.Now)
                .SetClientId(1)
                .Build();
            accRepo.Create(acc);
            Assert.IsTrue(accRepo.Update(acc));
            RemoveAll();
        }

        [TestMethod]
        public void TestDeleteAccount()
        {
            RemoveAll();
            Client cl = new ClientBuilder()
                .SetId(1)
                .SetName("name")
                .SetAddress("address")
                .Build();
            clientRepo.Create(cl);
            Account acc = new AccountBuilder()
                .SetId(1)
                .SetType("spending")
                .SetAmountMoney(1.0)
                .SetCreationDate(DateTime.Now)
                .SetClientId(1)
                .Build();
            accRepo.Create(acc);
            Assert.IsTrue(accRepo.Delete(acc));
            RemoveAll();
        }

        [TestMethod]
        public void TestFindAccountById()
        {
           Account acc = accRepo.GetAccountById(0);
            Assert.IsNull(acc);
        }
    }
}