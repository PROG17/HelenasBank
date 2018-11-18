using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Models
{
    public class Account
    {
        public string AccountNo { get; set; }

        public int CustomerId { get; set; }

        public decimal Balance { get; set; }

        public bool TransferFromAccount(Account receivingAccount, decimal amount)
        {
            if (this.Balance < amount)
            {
                return false;
            }
            else
            {

                this.Balance -= amount;
                receivingAccount.Balance += amount;
                return true;
            }


        }
    }
}
