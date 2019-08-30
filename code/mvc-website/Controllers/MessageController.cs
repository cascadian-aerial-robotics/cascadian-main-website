using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cascadian.Website.Abstractions;
using CascadianAerialRobotics.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadianAerialRobotics.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public IContactMessageLogger ContactMessageLogger { get; set; }
        public MessageController(IContactMessageLogger contactMessageLogger)
        {
            ContactMessageLogger = contactMessageLogger;
        }

        // POST: api/Message
        [HttpPost]
        public void Post([FromBody] ContactMessage message)
        {
            ContactMessageLogger.SaveMessage(message.Name, message.Email, message.Message, "Contact-us").Wait();

        }
    }
}
