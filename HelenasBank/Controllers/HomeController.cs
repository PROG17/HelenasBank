﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelenasBank.Models;
using HelenasBank.Repo;

namespace HelenasBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankRepository _repo;

        public HomeController(IBankRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var customers = _repo.ImportCustomers();
            return View(customers);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
