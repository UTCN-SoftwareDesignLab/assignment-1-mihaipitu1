using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Repository.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Tests.Repository
{
    [TestClass]
    public class ClientRepositoryMySQLTest
    {
        private IClientRepository clientRepo;

        public ClientRepositoryMySQLTest()
        {
            clientRepo = new ClientRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true));
        }

        public void RemoveAll()
        {
            List<Client> clients = clientRepo.FindAll();
            foreach (var client in clients)
            {
                clientRepo.Delete(client);
            }
        }

        [TestMethod]
        public void TestFindAllClients()
        {
            RemoveAll();
            List<Client> clients = clientRepo.FindAll();
            Assert.AreEqual(clients.Count, 0);
            RemoveAll();
        }

        [TestMethod]
        public void TestCreateClient()
        {
            RemoveAll();
            Client cl = new ClientBuilder()
                .SetId(1)
                .SetName("Name")
                .SetAddress("Address")
                .Build();
            Assert.IsTrue(clientRepo.Create(cl));
            RemoveAll();
        }

        [TestMethod]
        public void TestUpdateClient()
        {
            RemoveAll();
            Client cl = new ClientBuilder()
                .SetId(1)
                .SetName("Name")
                .SetAddress("Address")
                .Build();
            clientRepo.Create(cl);
            cl.SetAddress("Add");
            Assert.IsTrue(clientRepo.Update(cl));
            RemoveAll();
        }

        [TestMethod]
        public void TestDeleteClient()
        {
            RemoveAll();
            Client cl = new ClientBuilder()
                .SetId(1)
                .SetName("Name")
                .SetAddress("Address")
                .Build();
            clientRepo.Create(cl);
            Assert.IsTrue(clientRepo.Delete(cl));
            RemoveAll();
        }

        [TestMethod]
        public void TestFindClientById()
        {
            Client client = clientRepo.GetClientById(0);
            Assert.IsNull(client);
        }
    }
}