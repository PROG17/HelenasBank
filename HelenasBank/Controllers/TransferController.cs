using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenasBank.Models;
using HelenasBank.Repo;
using HelenasBank.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelenasBank.Controllers
{
    public class TransferController : Controller
    {
        private IBankRepository _repository;
        public TransferController(IBankRepository repository)
        {
            _repository = repository;

        }

        public IActionResult Transfer()
        {
            var model = new TransferViewModel()
            {
                TransferingAccount = new Models.Account(),
                ReceivingAccount = new Models.Account()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Transfer(TransferViewModel model)
        {
 

            if (ModelState.IsValid)
            {
                var receivingAccount = new Account();

                var transferingAccount = new Account();

                receivingAccount = _repository.GetCustomers().SelectMany(x => x.Accounts.Where(y => y.AccountNo == model.ReceivingAccount.AccountNo)).SingleOrDefault();

                transferingAccount = _repository.GetCustomers().SelectMany(x => x.Accounts.Where(y => y.AccountNo == model.TransferingAccount.AccountNo)).SingleOrDefault();

                if (transferingAccount == null || receivingAccount == null)
                {
                    ModelState.AddModelError("", "Account number doesn't exist.");
                    model.ReceivingAccount = new Account();
                    model.TransferingAccount = new Account();
                    return View(model);
                }

                model.ReceivingAccount.Balance = receivingAccount.Balance;
                model.TransferingAccount.Balance = transferingAccount.Balance;

                var result = model.TransferingAccount.TransferFromAccount(model.ReceivingAccount, model.Amount);
                if (result)
                {


                    return View(model);

                }
                else
                {
                    ModelState.AddModelError("", "Balance is too low.");
                    return View(model);

                }

            }
            else
            {
                return View(model);
            }
        }
    }
}