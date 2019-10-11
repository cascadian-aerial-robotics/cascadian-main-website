using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadianAerialRobotics.Website.Models
{

    public class PageMetadataModel
    {
        public string Page { get; set; }

        public string Description { get; set; }

        public string BodyClass
        {
            get
            {
                return _bodyClass ?? "dark-load"; // Default class.
            }
            set
            {
                _bodyClass = value;
            }
        }
        private string _bodyClass = null;


    }
}
