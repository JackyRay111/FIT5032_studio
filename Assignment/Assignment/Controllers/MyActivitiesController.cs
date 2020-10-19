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

namespace Assignment.Controllers
{
    public class MyActivitiesController : Controller
    {
        private AssignmentModel db = new AssignmentModel();
        // GET: MyActivities
        public ActionResult MyActivity()
        {
            var userId = User.Identity.GetUserId();
            var record = db.JoinLogs.Include(a => a.Activity).Where(a => a.AspNetUserId == userId);
            return View(record.ToList());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JoinLog joinLog = db.JoinLogs.Find(id);
            if (joinLog == null)
            {
                return HttpNotFound();

            }
            return View(joinLog);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JoinLog joinLog = db.JoinLogs.Find(id);
            db.JoinLogs.Remove(joinLog);
            db.SaveChanges();
            return RedirectToAction("MyActivity");
        }
    }
}
