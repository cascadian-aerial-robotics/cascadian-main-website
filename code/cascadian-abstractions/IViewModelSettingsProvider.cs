using System;
using System.Collections.Generic;
using System.Text;

namespace Cascadian.Abstractions
{
    public interface IViewModelSettingsProvider
    {
        string StaticFilesUrl { get; }

        bool UseLocalStyleBackgroundSetting { get; }

    }
}
