using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CascadianAerialRobotics.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadianAerialRobotics.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        // POST: api/Message
        [HttpPost]
        public void Post([FromBody] ContactMessage message)
        {
            
        }
    }
}
