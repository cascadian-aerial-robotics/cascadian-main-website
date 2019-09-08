
using Cascadian.Abstractions;

namespace CascadianAerialRobotics.Website.Models
{
    public class CommonComponentModel
    {
        public PageMetadataModel Metadata { get; set; }
        public IPubliclyExposedStringsProvider PubliclyExposedStringsProvider { get; set; }
    }
}
