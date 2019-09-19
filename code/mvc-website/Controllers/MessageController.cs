using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cascadian.Website.Abstractions;
using CascadianAerialRobotics.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CascadianAerialRobotics.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public IContactMessageLogger ContactMessageLogger { get; set; }

        public ILogger Logger { get; set; }

        public MessageController(IContactMessageLogger contactMessageLogger, ILogger logger)
        {
            ContactMessageLogger = contactMessageLogger;
            Logger = logger;
        }

        // POST: api/Message
        [HttpPost]
        public void Post([FromBody] ContactMessage message)
        {
            // TODO: Validation.

            try
            {
                ContactMessageLogger.SaveMessage(message.Name, message.Email, message.Message, "Contact-us").Wait();
                Logger.LogInformation("Contact message has been sent.");
            }
            catch (Exception ex)
            {
                var applicationException = new ApplicationException("A failure has occured sending a contact message.", ex);
                if(Logger != null)
                {
                    Logger.LogError(applicationException, ex.ToString());
                }
                
                throw;
            }

        }
    }
}
