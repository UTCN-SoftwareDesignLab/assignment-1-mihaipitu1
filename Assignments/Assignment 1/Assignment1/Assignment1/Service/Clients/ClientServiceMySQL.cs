using System;
using System.Collections.Generic;
using System.Diagnostics;
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
           // Debug.WriteLine("Clients: "+ client.GetId() +" "+ name+ " " +address);
            return clientRepo.Update(client);
        }

        public Client GetClientById(long id)
        {
            return clientRepo.GetClientById(id);
        }

        public long GetMaxId()
        {
            List<Client> clients = GetClients();
            long id = -1;
            foreach(Client client in clients)
            {
                if (id < client.GetId())
                { 
                    id = client.GetId();
                }
            }
            return id;
        }
    }
}
