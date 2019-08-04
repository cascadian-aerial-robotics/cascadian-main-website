using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Views.Shared.Components.Industries
{
    public class IndustriesViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}
