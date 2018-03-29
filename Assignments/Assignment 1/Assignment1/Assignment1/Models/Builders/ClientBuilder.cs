using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models.Builders
{
    public class ClientBuilder
    {
        private Client client;

        public ClientBuilder()
        {
            client = new Client();
        }

        public ClientBuilder SetId(long id)
        {
            client.SetId(id);
            return this;
        }

        public ClientBuilder SetName(string name)
        {
            client.SetName(name);
            return this;
        }

        public ClientBuilder SetAddress(string address)
        {
            client.SetAddress(address);
            return this;
        }

        public Client Build()
        {
            return client;
        }
    }
}
