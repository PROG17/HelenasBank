using HelenasBank.Classes;
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
        private static List<Customer> Customers { get; set; }
        BankHelper bankHelper = new BankHelper();

        public BankRepository()
        {
            if (Customers == null)
            {
                Customers = new List<Customer>();
                Customers = ImportCustomers();
            }
        }

        public string Deposit(string accountNo, int ammount)
        {
            var isExistingAccount = IsCorrectAccountNo(accountNo);

            if (!isExistingAccount)
            {
                return "Du har inte fyllt i ett giltigt kontonummer, försök igen!";
            }
            else
            {
                decimal currentBalance = 0;
                Account currentAccount;
                foreach (var cust in Customers)
                {
                    currentAccount = cust.Accounts.Where(a => a.AccountNo == accountNo).FirstOrDefault();
                    if (currentAccount != null)
                    {
                        currentBalance = currentAccount.Balance;
                       
                        currentAccount.Balance = bankHelper.PerformDeposit(currentBalance, ammount);
                        return string.Format("Ditt konto {0} hade tidigare saldot {1} men innehåller nu {2} kr", currentAccount.AccountNo, currentBalance, currentAccount.Balance);

                    }
                }
                return string.Format("Något gick fel");
            }

        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }

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
                    Id = int.Parse(arrayOfCustomer[0]),
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
                    CustomerId = int.Parse(arrayOfAccount[1]),
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

        public bool IsCorrectAccountNo(string accountNo)
        {
            List<Account> foundAccount = new List<Account>();
            foreach (var cust in Customers)
            {
                foundAccount = cust.Accounts.Where(a => a.AccountNo == accountNo).ToList();

                if (foundAccount.Any())
                {
                    return true;

                }
            }

            return false;

        }

        public string Withdrawal(string accountNo, int ammount)
        {
            var isExistingAccount = IsCorrectAccountNo(accountNo);

            if (!isExistingAccount)
            {
                return "Du har inte fyllt i ett giltigt kontonummer, försök igen!";
            }

            else
            {
                decimal currentBalance = 0;
                Account currentAccount;
                foreach (var cust in Customers)
                {
                    currentAccount = cust.Accounts.Where(a => a.AccountNo == accountNo).FirstOrDefault();
                    if (currentAccount != null)
                    {
                        currentBalance = currentAccount.Balance;

                        if (currentBalance < ammount)
                        {
                            return string.Format("Du får inte ta ut mer pengar än du har på kontot. Du har för tillfället {0} kr på ditt konto.", currentBalance);
                        }
                        
                        currentAccount.Balance = bankHelper.PerformWithdrawal(currentBalance, ammount);
                        return string.Format("Ditt konto {0} hade tidigare saldot {1} men innehåller nu {2} kr", currentAccount.AccountNo, currentBalance, currentAccount.Balance);

                    }
                }
                return "Något gick snett, testa igen!";
            }
        }

    }
}
