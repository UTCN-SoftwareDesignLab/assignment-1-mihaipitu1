using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Service.Clients
{
    public interface IClientService
    {
        List<Client> GetClients();

        bool DeleteClient(Client client);

        bool CreateClient(Client client);

        bool UpdateClient(Client oldClient, string name, string address);
    }
}
