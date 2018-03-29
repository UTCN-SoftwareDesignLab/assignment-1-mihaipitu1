using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Repository.Clients;

namespace Assignment1.Service.Clients
{
    public class ClientServiceMySQL : IClientService
    {
        IClientRepository clientRepo;
        public ClientServiceMySQL(IClientRepository clientRepo)
        {
            this.clientRepo = clientRepo;
        }

        public bool CreateClient(Client client)
        {
            return clientRepo.Create(client);
        }

        public bool DeleteClient(Client client)
        {
            return clientRepo.Delete(client);
        }

        public List<Client> GetClients()
        {
            return clientRepo.FindAll();
        }

        public bool UpdateClient(Client oldClient, string name, string address)
        {
            Client client = new ClientBuilder()
                .SetId(oldClient.GetId())
                .SetName(name)
                .SetAddress(address)
                .Build();
            return clientRepo.Update(client);
        }
    }
}
