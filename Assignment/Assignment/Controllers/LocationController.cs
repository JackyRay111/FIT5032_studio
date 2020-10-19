using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class LocationController : Controller
    {
        private AssignmentModel db = new AssignmentModel();
        public ActionResult Place()
        {
            var place = db.ActivityPlaces.ToList();
            return View(place);
        }
    }
}
