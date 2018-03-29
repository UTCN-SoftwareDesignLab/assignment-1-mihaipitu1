using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class SavingAccount : Account
    {
        private static double interestRate;
        private static double minAmount;

        public double GetInterestRate()
        {
            return interestRate;
        }

        public void SetInterestRate(double InterestRate)
        {
            interestRate = InterestRate;
        }

        public double GetMinAmount()
        {
            return minAmount;
        }

        public void SetMinAmount(double MinAmount)
        {
            minAmount = MinAmount;
        }
    }

}
