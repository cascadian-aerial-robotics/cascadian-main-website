using Microsoft.Extensions.DependencyInjection;

namespace CascadianAerialRobotics.Website.DependencyProfiles.Production
{
    public static class ProductionProfileExtensions
    {
        public static void AddProductionProfile(this IServiceCollection services)
        {
            new ProductionProfile().BuildDependencies(services);
        }
    }
}
