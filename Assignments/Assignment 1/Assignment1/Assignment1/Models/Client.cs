﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Client
    {
        private long id;
        private string name;
        private string address;

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
        public string Name
        {
            get
            {
                return GetName();
            }
            set
            {
                SetName(value);
            }
        }
        public string Address
        {
            get
            {
                return GetAddress();
            }
            set
            {
                SetAddress(value);
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

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            name = Name;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string Address)
        {
            address = Address;
        }
    }
}
