using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Views.Shared.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}
