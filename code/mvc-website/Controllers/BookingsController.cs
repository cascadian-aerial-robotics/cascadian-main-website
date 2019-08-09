using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mvc_website.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Do not hardcode this
            return this.Redirect("https://outlook.office365.com/owa/calendar/CascadianAerialRobotics@cascadianaerialrobotics.com/bookings/");
        }
    }
}