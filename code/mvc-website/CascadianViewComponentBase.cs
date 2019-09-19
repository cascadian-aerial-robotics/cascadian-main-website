using Cascadian.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CascadianAerialRobotics.Website.Components
{
    
    public abstract class CascadianViewComponentBase : ViewComponent
    {
        public IViewModelSettingsProvider PubliclyExposedStringsProvider { get; set; }

        public CascadianViewComponentBase(IViewModelSettingsProvider publiclyExposedStringsProvider)
        {
            PubliclyExposedStringsProvider = publiclyExposedStringsProvider;
        }

    }
}
