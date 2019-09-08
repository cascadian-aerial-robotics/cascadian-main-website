using System;
using System.Collections.Generic;
using System.Text;

namespace Cascadian.Abstractions
{
    public interface IViewModelSettingsProvider
    {
        string StaticFilesUrl { get; }

        string LegacyImagesUrl { get;  }

        bool UseLocalStyleBackgroundSetting { get; }

    }
}
