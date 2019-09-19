using Cascadian.Abstractions;
using CascadianAerialRobotics.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Components
{ 
    public class CitiesServedStripViewComponent : CascadianViewComponentBase
    {
        public CitiesServedStripViewComponent(IViewModelSettingsProvider publiclyExposedStringsProvider) : base(publiclyExposedStringsProvider)
        {
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default",  new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider }));
        }
    }
}
