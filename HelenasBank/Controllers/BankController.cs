using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenasBank.Repo;
using Microsoft.AspNetCore.Mvc;

namespace HelenasBank.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankRepository _repo;

        public BankController(IBankRepository repo)
        {
            _repo = repo;
        }
        public IActionResult DepositWithdrawal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepositWithdrawal(string accountNo, decimal ammount, string btn)
        {
            string result = "";
            if (btn == "Insättning")
            {
                result = _repo.Deposit(accountNo, ammount);
            }

            else
            {
                result = _repo.Withdrawal(accountNo, ammount);
            }

            return PartialView("_DepositWithdrawPartial", result);
        }
    }
}