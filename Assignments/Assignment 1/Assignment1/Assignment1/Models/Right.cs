using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Right
    {
        private string right;

        public Right( string right)
        {
            this.right = right;
        }

        public string GetRight()
        {
            return right;
        }

        public void SetRight(string right)
        {
            this.right = right;
        }
    }
}
