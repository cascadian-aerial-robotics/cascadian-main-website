
using Cascadian.Abstractions;
using CascadianAerialRobotics.Website.Models;
using Grump.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mvc_website.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Controllers
{
    public class HomeController : CascadianControllerBase
    {

        public HomeController(IConfiguration configuration, ISecretsProvider secretsProvider, ILogger logger, IViewModelSettingsProvider publiclyExposedStringsProvider) : base(configuration, secretsProvider, logger, publiclyExposedStringsProvider)
        {

        }

        public bool ShouldRedirectToStaticPage => Configuration.GetValue<bool>("Behavior:redirecttostatic");

        public IActionResult Index()
        {
            try
            {
                // If configured to redirect to static (most likely prod)
                if (ShouldRedirectToStaticPage)
                {
                    Task.Run(() => Logger.LogWarning(new EventId(1, "Request for root received."), "Request for root received."));
                    return this.RedirectPermanent("https://www.cascadianaerialrobotics.com");
                }
                
                // Proceed normally 
                var pageinfo = new PageMetadataModel
                {
                    Page = "Cascadian Aerial Robotics LLC - Drone mapping, photogrammetry and GIS services in the Pacific Northwest",
                    Description = "Cascadian Aerial Robotics LLC offers drone and mapping services to Washington State and the Pacific Northwest in general."
                };

                return View(new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider, Metadata = pageinfo });


            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Something went wrong when accesing the site from Index");
                return this.RedirectPermanent("https://www.cascadianaerialrobotics.com");
            }

            
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            // If configured to redirect to static (most likely prod)
            if (ShouldRedirectToStaticPage)
            {
                Task.Run(() => Logger.LogWarning(new EventId(1, "Request for non-root received." + this.HttpContext.Request.Path.Value), "Request for root received."));
                return this.RedirectPermanent("https://www.cascadianaerialrobotics.com");
            }

            var pageinfo = new PageMetadataModel
            {
                Page = "Privacy | Cascadian Aerial Robotics LLC",
                Description = "Privacy policy that regulates the website for Cascadian Aerial Robotics LLC."
            };

            return View("Privacy", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider, Metadata = pageinfo });
        }

        [Route("Newsletter")]
        public IActionResult Newsletter()
        {
            // If configured to redirect to static (most likely prod)
            if (ShouldRedirectToStaticPage)
            {
                Task.Run(() => Logger.LogWarning(new EventId(1, "Request for non-root received." + this.HttpContext.Request.Path.Value), "Request for root received."));
                return this.RedirectPermanent("https://www.cascadianaerialrobotics.com");
            }

            var pageinfo = new PageMetadataModel
            {
                Page = "Feathered flight: The Cascadian Aerial Robotics newsletter",
                Description = "The current issue of Feathered flight, the Cascadian Aerial Robotics newsletter."
            };

            return View("Newsletter", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider, Metadata = pageinfo });
        }

        [Route("Bookings")]
        public IActionResult Bookings()
        {
            // If configured to redirect to static (most likely prod)
            if (ShouldRedirectToStaticPage)
            {
                Task.Run(() => Logger.LogWarning(new EventId(1, "Request for non-root received." + this.HttpContext.Request.Path.Value), "Request for root received."));
                return this.RedirectPermanent("https://www.cascadianaerialrobotics.com");
            }

            var pageinfo = new PageMetadataModel
            {
                Page = "Bookings | Cascadian Aerial Robotics LLC",
                Description = "Book a meeting or call with Cascadian Aerial Robotics."
            };

            return View("Bookings", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider, Metadata = pageinfo });
        }

        [Route("FAQ")]
        public IActionResult Faq()
        {
            // If configured to redirect to static (most likely prod)
            if (ShouldRedirectToStaticPage)
            {
                Task.Run(() => Logger.LogWarning(new EventId(1, "Request for non-root received." + this.HttpContext.Request.Path.Value), "Request for root received."));
                return this.RedirectPermanent("https://www.cascadianaerialrobotics.com");
            }

            var pageinfo = new PageMetadataModel
            {
                Page = "Frequently asked questions | Cascadian Aerial Robotics LLC",
                Description = "The questions some of our customers or potential customers often have."
            };

            return View("Faq", new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider, Metadata = pageinfo });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
