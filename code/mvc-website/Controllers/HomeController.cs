﻿
using Grump.Abstractions;
using Microsoft.AspNetCore.Mvc;
using mvc_website.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Controllers
{
    public class HomeController : Controller
    {
        public ISecretsProvider SecretsProvider { get; private set; }

        public HomeController(ISecretsProvider secretsProvider)
        {
            SecretsProvider = secretsProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [Route("Newsletter")]
        public IActionResult Newsletter()
        {
            return View("Newsletter");
        }

        [Route("Newsletter2")]
        public IActionResult Newsletter2()
        {
            return View("Newsletter2");
        }

        [Route("Bookings")]
        public IActionResult Bookings()
        {
            return View("Bookings");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
