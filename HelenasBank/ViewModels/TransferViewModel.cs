using HelenasBank.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelenasBank.ViewModels
{
    public class TransferViewModel
    {
        public Account TransferingAccount { get; set; }

        public Account ReceivingAccount { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }


    }
}
