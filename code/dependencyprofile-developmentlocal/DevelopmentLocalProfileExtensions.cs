using Microsoft.Extensions.DependencyInjection;

namespace CascadianAerialRobotics.Website.DependencyProfiles.DevelopmentLocal
{
    public static class ProductionProfileExtensions
    {
        public static void AddDevelopmentLocalProfile(this IServiceCollection services)
        {
            new DevelopmentLocalProfile().BuildDependencies(services);
        }
    }
}
