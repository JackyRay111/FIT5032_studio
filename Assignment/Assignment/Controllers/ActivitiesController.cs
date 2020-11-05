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

        // Get the whole activity list
        [Authorize]
        public ActionResult Index()
        {
            var activities = db.Activities;
            return View(activities.ToList());
        }

        // Get the course list
        [Authorize]
        public ActionResult Course()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.Where(a => a.ActivityTypeId == 1).ToList());
        }

        // Get the QE list
        [Authorize]
        public ActionResult QulitifyE()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.Where(a => a.ActivityTypeId == 2).ToList());
        }

        // Get the Event list 
        [Authorize]
        public ActionResult Event()
        {
            var activities = db.Activities.Include(a => a.ActivityCategory).Include(a => a.ActivityPlace).Include(a => a.ActivityType);
            return View(activities.Where(a => a.ActivityTypeId == 3).ToList());
        }

        // The user click book button, a email will activity details will be sent to the user
        [Authorize(Roles = "User")]
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

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName");
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName");
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            return View();
        }

        // POST: ActivitiesTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,ActivityName,ActivityStartDate,ActivityDescription,ActivityTypeId,ActivityPlaceId,ActivityCategoryId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName", activity.ActivityCategoryId);
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName", activity.ActivityPlaceId);
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            return View(activity);
        }

        // GET: ActivitiesTest/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName", activity.ActivityCategoryId);
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName", activity.ActivityPlaceId);
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            return View(activity);
        }

        // POST: ActivitiesTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,ActivityName,ActivityStartDate,ActivityDescription,ActivityTypeId,ActivityPlaceId,ActivityCategoryId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName", activity.ActivityCategoryId);
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName", activity.ActivityPlaceId);
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            return View(activity);
        }

        // GET: ActivitiesTest/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: ActivitiesTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
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
