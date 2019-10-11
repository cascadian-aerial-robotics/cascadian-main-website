using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cascadian.Abstractions;
using CascadianAerialRobotics.Website.Models;
using Grump.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CascadianAerialRobotics.Website.Controllers
{ 
    public class BlogController : CascadianControllerBase
    {
        public BlogController(IConfiguration configuration, ISecretsProvider secretsProvider, ILogger logger, IViewModelSettingsProvider publiclyExposedStringsProvider) : base(configuration, secretsProvider, logger, publiclyExposedStringsProvider)
        {

        }

        public IActionResult Index()
        {
            var pageinfo = new PageMetadataModel
            {
                Page = "NW107 - The Cascadian Aerial Robotics Blog",
                Description = "Northwest 107. A blog about the commercial uses of drones.",
                BodyClass = "blog-page"
            };

            return View(new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider, Metadata = pageinfo });

        }
    }
}