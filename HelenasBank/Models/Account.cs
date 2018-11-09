using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Models
{
    public class Account
    {
        public string AccountNo { get; set; }

        public string CustomerId { get; set; }

        public decimal Balance { get; set; }
    }
}
