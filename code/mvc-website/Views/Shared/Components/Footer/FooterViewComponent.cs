using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Views.Components.FooterComponent
{
    public class FooterViewComponent : ViewComponent
    {
        public FooterViewComponent()
        {
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}
