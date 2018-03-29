using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Database
{
    public class DBConnectionFactory
    {
        public DBConnectionWrapper GetConnectionWrapper(bool test)
        {
            if(test)
            {
                return new DBConnectionWrapper("bank_test");
            }
            return new DBConnectionWrapper("bank");
        }
    }
}
