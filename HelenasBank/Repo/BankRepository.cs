using HelenasBank.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Repo
{
    public class BankRepository : IBankRepository
    {
        public List<Customer> ImportCustomers()
        {
            var path = Path.GetFullPath("bankdata-small.txt");
            path = path.Replace("bankdata-small.txt", "Files\\bankdata-small.txt");

            List<Customer> listOfCustomers = new List<Customer>();
            var reader = new StreamReader(path);

            int Customers = int.Parse(reader.ReadLine());

            for (int i = 0; i < Customers; i++)
            {
                string cust = reader.ReadLine();
                string[] arrayOfCustomer = cust.Split(';');
                var customer = new Customer()
                {
                    Id = arrayOfCustomer[0],
                    OrgNumber = arrayOfCustomer[1],
                    Name = arrayOfCustomer[2],
                    Address = arrayOfCustomer[3],
                    City = arrayOfCustomer[4],
                    State = arrayOfCustomer[5],
                    ZipCode = arrayOfCustomer[6],
                    Country = arrayOfCustomer[7],
                    Phone = arrayOfCustomer[8]
                };
                listOfCustomers.Add(customer);
            }

            var numberOfAccounts = int.Parse(reader.ReadLine());

            for (int i = 0; i < numberOfAccounts; i++)
            {
                string acc = reader.ReadLine();
                string[] arrayOfAccount = acc.Split(';');

                var account = new Account()
                {
                    AccountNo = arrayOfAccount[0],
                    CustomerId = arrayOfAccount[1],
                    Balance = decimal.Parse(arrayOfAccount[2], CultureInfo.InvariantCulture)
                };

                foreach (var cust in listOfCustomers)
                {
                    if (cust.Id == account.CustomerId)
                    {
                        cust.Accounts.Add(account);
                    }
                }

            }

            return listOfCustomers;
        }
    }
}
