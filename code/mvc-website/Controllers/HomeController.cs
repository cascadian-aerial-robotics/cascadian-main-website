
using Cascadian.Abstractions;
using CascadianAerialRobotics.Website.Models;
using Grump.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mvc_website.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Controllers
{
    public class HomeController : CascadianControllerBase
    {

        public HomeController(IConfiguration configuration, ISecretsProvider secretsProvider, ILogger logger, IPubliclyExposedStringsProvider publiclyExposedStringsProvider) : base(configuration, secretsProvider, logger, publiclyExposedStringsProvider)
        {

        }

        public IActionResult Index()
        {
            return View(new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider });
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View("Privacy", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider });
        }

        [Route("Newsletter")]
        public IActionResult Newsletter()
        {
            return View("Newsletter", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider });
        }

        [Route("Newsletter2")]
        public IActionResult Newsletter2()
        {
            return View("Newsletter2", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider });
        }

        [Route("Bookings")]
        public IActionResult Bookings()
        {
            return View("Bookings", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider });
        }

        [Route("FAQ")]
        public IActionResult Faq()
        {
            return View("Faq", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
