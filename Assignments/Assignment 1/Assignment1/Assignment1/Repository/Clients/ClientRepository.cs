using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repository.Clients
{
    public interface IClientRepository : BaseRepository<Client>
    {
        Client GetClientById(long id);
    }
}
