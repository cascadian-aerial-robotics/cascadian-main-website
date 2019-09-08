using Cascadian.Abstractions;
using Grump.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CascadianAerialRobotics.Website.Controllers
{
    public abstract class CascadianControllerBase : Controller
    {
        public IConfiguration Configuration { get; set; }

        public ISecretsProvider SecretsProvider { get; private set; }

        public ILogger Logger { get; set; }

        public IViewModelSettingsProvider PubliclyExposedStringsProvider { get; set; }

        public CascadianControllerBase(IConfiguration configuration, ISecretsProvider secretsProvider, ILogger logger, IViewModelSettingsProvider publiclyExposedStringsProvider)
        {
            Configuration = configuration;
            SecretsProvider = secretsProvider;
            Logger = logger;
            PubliclyExposedStringsProvider = publiclyExposedStringsProvider;
        }

    }
}
