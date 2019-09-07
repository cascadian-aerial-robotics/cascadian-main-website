using Cascadian.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CascadianAerialRobotics.Website.Components
{
    
    public abstract class CascadianViewComponentBase : ViewComponent
    {
        public IPubliclyExposedStringsProvider PubliclyExposedStringsProvider { get; set; }

        public CascadianViewComponentBase(IPubliclyExposedStringsProvider publiclyExposedStringsProvider)
        {
            PubliclyExposedStringsProvider = publiclyExposedStringsProvider;
        }

    }
}
