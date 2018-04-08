using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Account
    {
        private long id;
        private double amountMoney;
        private string type;
        private DateTime creationDate;
        private long clientId;
        private Client client;

        public long Id
        {
            get
            {
                return GetId();
            }
            set
            {
                SetId(value);
            }
        }

        public double AmountMoney
        {
            get
            {
                return GetAmountMoney();
            }
            set
            {
                SetAmountMoney(value);
            }
        }

        public long ClientId
        {
            get
            {
                return GetClientId();
            }
            set
            {
                SetClientId(value);
            }
        }

        public string Type
        {
            get
            {
                return GetType();
            }
            set
            {
                SetType(value);
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return GetCreationDate();
            }
            set
            {
                SetCreationDate(value);
            }
        }
        public Client Client
        {
            get
            {
                return GetClient();
            }
            set
            {
                SetClient(value);
            }
        }
        public long GetId()
        {
            return id;
        }

        public void SetId(long Id)
        {
            id = Id;
        }

        public double GetAmountMoney()
        {
            return amountMoney;
        }

        public void SetAmountMoney(double AmountMoney)
        {
            amountMoney = AmountMoney;
        }

        public string GetType()
        {
            return type;
        }

        public void SetType(string Type)
        {
            type = Type;
        }

        public DateTime GetCreationDate()
        {
            return creationDate;
        }

        public void SetCreationDate(DateTime CreationDate)
        {
            creationDate = CreationDate;
        }

        public Client GetClient()
        {
            return client;
        }

        public long GetClientId()
        {
            return clientId;
        }
        public void SetClientId(long ClientId)
        {
            clientId = ClientId;
        }

        public void SetClient(Client Client)
        {
            client = Client;
        }
    }
}
