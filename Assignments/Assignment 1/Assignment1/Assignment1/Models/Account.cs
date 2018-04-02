using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public abstract class Account
    {
        private long id;
        private double amountMoney;
        private DateTime creationDate;
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

        public void SetClient(Client Client)
        {
            client = Client;
        }
    }
}
