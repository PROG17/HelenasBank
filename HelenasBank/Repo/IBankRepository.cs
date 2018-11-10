using HelenasBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Repo
{
    public interface IBankRepository
    {
        List<Customer> GetCustomers();

        List<Customer> ImportCustomers();

        bool IsCorrectAccountNo(string accountNo);

        string Deposit(string accountNo, int ammount);

        string Withdrawal(string accountNo, int ammount);

    }
}
