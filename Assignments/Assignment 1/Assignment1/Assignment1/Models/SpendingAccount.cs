using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class SpendingAccount : Account
    {
        private static int freeTransactions;
        private static double transactionFee;
        private int noTransactions;

        public int GetFreeTransactions()
        {
            return freeTransactions;
        }

        public void SetFreeTransactions(int FreeTransactions)
        {
            freeTransactions = FreeTransactions;
        }

        public double GetTransactionFee()
        {
            return transactionFee;
        }

        public void SetTransactionFee(double TransactionFee)
        {
            transactionFee = TransactionFee;
        }

        public int GetNoTransactions()
        {
            return noTransactions;
        }

        public void SetNoTransactions(int NoTransactions)
        {
            noTransactions = NoTransactions;
        }
    }
}
