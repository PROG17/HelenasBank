﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.Classes
{
    public class BankHelper
    {
        public decimal PerformDeposit(decimal balance, decimal ammount)
        {
            return balance + ammount;
        }

        public decimal PerformWithdrawal(decimal balance, decimal ammount)
        {
            if(ammount > balance)
            {
                return balance;
            }

            return balance - ammount;
        }
    }
}
