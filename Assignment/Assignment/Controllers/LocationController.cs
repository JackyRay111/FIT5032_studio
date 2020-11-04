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

        // Get the place list 
        [Authorize]
        public ActionResult Place()
        {
             
            var place = db.ActivityPlaces.ToList();
            
            foreach (var item in place)
            {
                var rating = db.RatingLogs.Where(a => a.ActivityPlaceId == item.Id);
                if (rating.Count() == 0)
                {
                    item.Rating = 0;
                }
                else {
                    item.Rating = db.RatingLogs.Where(a => a.ActivityPlaceId == item.Id).Average(a => a.Rating);
                }
               
            }

            return View(place);
        }
    }
}
