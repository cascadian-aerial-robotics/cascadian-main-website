using Cascadian.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Cascadian.Website.Services
{
    public class PubliclyExposedStringsProvider : IPubliclyExposedStringsProvider
    {
        public IConfiguration Configuration { get; set; }

#pragma warning disable CA1056 // Uri properties should not be strings
        public string StaticFilesUrl => Configuration["staticfilesurl"] ?? "";
#pragma warning restore CA1056 // There is no good use on spending compute on turning this into a Uri - Adrian.

        public PubliclyExposedStringsProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }


    }
}
