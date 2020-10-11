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

        // GET: Activities
        [Authorize]
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityPlace).Include(a => a.ActivityType).Include(a => a.ActivityCategory);
            return View(activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
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

        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName");
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityName,ActivityStartDate,ActivityDuration,ActivityDescription,ActivityStatus,ActivityRating,ActivityTypeId,ActivityPlaceId,ActivityCategoryId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName", activity.ActivityPlaceId);
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName", activity.ActivityCategoryId);
            return View(activity);
        }

        // GET: Activities/Edit/5
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
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName", activity.ActivityPlaceId);
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName", activity.ActivityCategoryId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityName,ActivityStartDate,ActivityDuration,ActivityDescription,ActivityStatus,ActivityRating,ActivityTypeId,ActivityPlaceId,ActivityCategoryId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityPlaceId = new SelectList(db.ActivityPlaces, "Id", "ActivityPlaceName", activity.ActivityPlaceId);
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "Id", "CategoryName", activity.ActivityCategoryId);
            return View(activity);
        }

        // GET: Activities/Delete/5
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

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
