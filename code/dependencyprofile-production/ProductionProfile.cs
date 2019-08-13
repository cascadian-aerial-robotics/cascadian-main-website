using Grump.Azure;
using Grump.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CascadianAerialRobotics.Website.ProductionDependencyProfile
{
    public class ProductionProfile : IDependencyProfile
    {
        public void BuildDependencies(IServiceCollection services)
        {
            services.AddScoped<ISecretsProvider, ManagedIdentityKeyVaultSecretsProvider>();
        }
    }
}
