﻿
using Microsoft.AspNetCore.Mvc;

namespace CascadianAerialRobotics.Website.Controllers
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