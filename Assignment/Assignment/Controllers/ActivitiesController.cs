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

        public ActionResult Book(int? id)
        {
            ViewBag.Message = "";
            var userId = User.Identity.GetUserId();
            var isNull = db.JoinLogs.Count();
            var joinLog = db.JoinLogs.Where(a => a.ActivityId == id && a.AspNetUserId == userId).Count();
            if (isNull == 0 || joinLog == 0)
            {
                var joinlog = new JoinLog();
                joinlog.ActivityId = id ?? default(int);
                joinlog.AspNetUserId = userId;
                joinlog.JoinDate = DateTime.Now;
                var user = db.UserProfiles.Find(userId);
                var activity = db.Activities.Find(id);
                EmailSender es = new EmailSender();

                if (ModelState.IsValid)
                {
                    db.JoinLogs.Add(joinlog);
                    db.SaveChanges();
                    ViewBag.Message = "you are successfully book this activity";
                    es.Send(activity, user);
                    return View();
                }
            }
            else if (joinLog != 0)
            {
                ViewBag.Message = "You have already book this activity";
                return View();
            }
            return View();
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
