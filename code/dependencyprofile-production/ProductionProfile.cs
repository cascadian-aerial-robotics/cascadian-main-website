using Grump.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Grump.Azure;
using Cascadian.Abstractions;
using Cascadian.Repositories.Sql;
using Cascadian.Website.Abstractions;
using Cascadian.Website.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.ApplicationInsights;

namespace CascadianAerialRobotics.Website.DependencyProfiles.Production
{
    public class ProductionProfile : IDependencyProfile
    {
        public void BuildDependencies(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.AddSingleton<ILogger>(new ApplicationInsightsLogger("main-webpage", new TelemetryClient(), new ApplicationInsightsLoggerOptions() { IncludeScopes = false }));


            services.AddSingleton<IKeyVaultClient, ManagedIdentityKeyVaultClient>();
            services.AddSingleton<ISecretsProvider, KeyVaultSecretsProvider>();
            services.AddTransient<IPersonRepository, SqlPersonRepository>();
            services.AddTransient<IContactInfoRepository, SqlContactInfoRepository>();
            services.AddTransient<IContactMessageRepository, SqlContactMessageRepository>();
            services.AddTransient<IContactMessageLogger, ContactMessageLogger>();

        }
    }
}
