﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Models;
using SocialNet.ViewModels.Account;

namespace SocialNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return View(new MainViewModel());
        }

        [Route("[action]")]
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