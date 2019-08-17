using Grump.Abstractions;
using Grump.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.DependencyInjection;

namespace CascadianAerialRobotics.Website.DependencyProfiles.Production
{
    public class ProductionProfile : IDependencyProfile
    {
        public void BuildDependencies(IServiceCollection services)
        {
            services.AddSingleton<IKeyVaultClient, ManagedIdentityKeyVaultClient>();
            services.AddSingleton<ISecretsProvider, KeyVaultSecretsProvider>();
        }
    }
}
