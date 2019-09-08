using Cascadian.Abstractions;
using Microsoft.Extensions.Configuration;
using System;

namespace Cascadian.Website.Services
{
    public class ConfigViewModelSettingsProvider : IViewModelSettingsProvider
    {
        public IConfiguration Configuration { get; set; }

#pragma warning disable CA1056 // Uri properties should not be strings
        public string StaticFilesUrl => Configuration["staticfilesurl"] ?? "";

        private const string InvalidUseLocalStyleBackgroundSettingMessage = "The setting 'uselocalstylebackgroundsetting' must be set to a boolean value. This setting determines whether to use the background-image css property directly in the divs";
#pragma warning restore CA1056 // There is no good use on spending compute on turning this into a Uri - Adrian.


        public bool UseLocalStyleBackgroundSetting
        {
            get
            {
                if (!_useLocalStyleBackgroundSetting.HasValue)
                {
                    try
                    {
                        var settingString = Configuration["uselocalstylebackgroundsetting"];

                        if (string.IsNullOrEmpty(settingString))
                            throw new ApplicationException(InvalidUseLocalStyleBackgroundSettingMessage);

                        bool boolValue;

                        if (bool.TryParse(settingString, out boolValue))
                        {
                            _useLocalStyleBackgroundSetting = boolValue;
                        }
                        else
                        {
                            throw new FormatException("InvalidUseLocalStyleBackgroundSettingMessage");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("An exception occured trying to parse the value of setting 'uselocalstylebackgroundsetting'. Verify the setting to be a valid boolean", ex);
                    }
                }

                return _useLocalStyleBackgroundSetting.Value;


            }
        }

        private bool? _useLocalStyleBackgroundSetting;


        public ConfigViewModelSettingsProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }


    }
}
