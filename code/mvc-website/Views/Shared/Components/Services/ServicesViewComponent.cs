using Cascadian.Abstractions;
using CascadianAerialRobotics.Website.Components;
using CascadianAerialRobotics.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Views.Shared.Components.Services
{
    public class ServicesViewComponent : CascadianViewComponentBase
    {
        public ServicesViewComponent(IViewModelSettingsProvider publiclyExposedStringsProvider) : base(publiclyExposedStringsProvider)
        {
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View(new CommonComponentModel { PubliclyExposedStringsProvider = this.PubliclyExposedStringsProvider }));
        }
    }
}
