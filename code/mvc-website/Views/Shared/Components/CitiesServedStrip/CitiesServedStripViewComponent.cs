using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Views.Shared.Components.CitiesServedStrip
{
    public class CitiesServedStripViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}
