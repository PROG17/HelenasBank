﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Models
{
    public class Customer
    {
        public Customer()
        {
            Accounts = new List<Account>();
        }
        public int Id { get; set; }

        public string OrgNumber { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
