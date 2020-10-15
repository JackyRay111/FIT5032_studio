using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class ActivitiesController : Controller
    {
        private AssignmentModel db = new AssignmentModel();

        [Authorize]
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.ToList());
        }

        // GET: Activities
        [Authorize]
        public ActionResult Course()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.Where(a => a.ActivityTypeId == 1).ToList());
        }

        [Authorize]
        public ActionResult QulitifyE()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.Where(a => a.ActivityTypeId == 2).ToList());
        }

        [Authorize]
        public ActionResult Event()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.Where(a => a.ActivityTypeId == 3).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
