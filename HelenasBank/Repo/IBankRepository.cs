using HelenasBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Repo
{
    public interface IBankRepository
    {
        List<Customer> ImportCustomers();
    }
}
