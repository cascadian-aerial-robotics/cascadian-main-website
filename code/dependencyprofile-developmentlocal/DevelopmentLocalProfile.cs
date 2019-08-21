using Grump.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Grump.Azure;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Cascadian.Abstractions;
using Cascadian.Repositories.Sql;
using Cascadian.Website.Abstractions;
using Cascadian.Website.Services;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;

namespace CascadianAerialRobotics.Website.DependencyProfiles.DevelopmentLocal
{
    public class DevelopmentLocalProfile : IDependencyProfile
    {
        public void BuildDependencies(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.AddSingleton<ILogger>(new ApplicationInsightsLogger("main-webpage", new TelemetryClient(), new ApplicationInsightsLoggerOptions() { IncludeScopes = false }));


            services.AddSingleton<IKeyVaultClient, ManagedIdentityKeyVaultClient>();
            services.AddSingleton<ISecretsProvider, KeyVaultSecretsProvider>();
            services.AddTransient<IPersonRepository, SqlPersonRepository>();
            services.AddTransient<IContactMessageLogger, ContactMessageLogger>();

        }
    }
}
