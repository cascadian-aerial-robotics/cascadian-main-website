using Cascadian.Abstractions;
using Microsoft.Extensions.Configuration;
using System;

namespace Cascadian.Website.Services
{
    public class ConfigViewModelSettingsProvider : IViewModelSettingsProvider
    {
        private IConfiguration Configuration { get; set; }

        public ConfigViewModelSettingsProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string LegacyImagesUrl => Configuration["FrontFacingSettings:legacyimagesurl"] ?? "";

        public string StaticContentUrl => Configuration["FrontFacingSettings:staticcontenturl"] ?? "";

        public string ModernImagesUrl => Configuration["FrontFacingSettings:modernimagesurl"] ?? "";


    }
}
