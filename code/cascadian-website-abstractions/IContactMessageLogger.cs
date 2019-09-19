using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cascadian.Website.Abstractions
{
    /// <summary>
    /// Provides an interface to the logger that receives messages from the Contact us sections of the page.
    /// </summary>
    public interface IContactMessageLogger
    {
        Task SaveMessage(string contactName, string contactEmail, string message, string contactOrigin, IEnumerable<KeyValuePair<string, string>> additionalFields = null);
    }
}
