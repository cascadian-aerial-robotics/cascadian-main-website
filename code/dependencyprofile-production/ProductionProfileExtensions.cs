using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
