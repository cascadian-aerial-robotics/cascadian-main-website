using System;
using System.Collections.Generic;
using System.Text;

namespace Cascadian.Abstractions
{
    public interface IViewModelSettingsProvider
    {
        string ModernImagesUrl { get; }

        string StaticContentUrl { get;  }

        string LegacyImagesUrl { get;  }

    }
}
