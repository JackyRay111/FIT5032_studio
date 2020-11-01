using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using Microsoft.AspNet.Identity;
using Assignment.Utils;

namespace Assignment.Controllers
{
    public class RatingController : Controller
    {
        private AssignmentModel db = new AssignmentModel();
        // GET: Rating
        public ActionResult Display (int? id)
        {
            var rating = db.RatingLogs.Where(a => a.ActivityPlaceId == id).ToList();
            ViewBag.Id = id;
            if (id != null)
            {
                ViewBag.Title = db.ActivityPlaces.Find(id).ActivityPlaceName;
            }
            return View(rating);
        }

        // POST: Rating/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RatingAndComment(int PlaceId, int Rating, string Comments)
        {
            var userId = User.Identity.GetUserId();


            
            if (ModelState.IsValid)
            {
                RatingLog rating = new RatingLog();
                rating.ActivityPlaceId = PlaceId;
                rating.Comments = Comments;
                rating.Rating = Rating;
                rating.AspNetUserId = userId;
                rating.RatingDate = DateTime.Now;
                db.RatingLogs.Add(rating);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Display", new { id = PlaceId });
        }


    }
}
