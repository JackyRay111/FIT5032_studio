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
    public class UserProfileController : Controller
    {
        private AssignmentModel db = new AssignmentModel();

        // GET: UserProfile/Edit/5
        [Authorize]
        public ActionResult EditAndCreate()
        {
            var userId = User.Identity.GetUserId();

           UserProfile userProfile = db.UserProfiles.Find(userId);
           if (userProfile == null)
           {
                userProfile = new UserProfile();
                userProfile.Id = userId;
           }
           return View(userProfile);
        }

        // POST: UserProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditAndCreate( UserProfile userProfile)
        {
            var userId = User.Identity.GetUserId();
            
            if (ModelState.IsValid)
            {
                var userP = db.UserProfiles.Find(userId);
                if (userP == null)
                {
                    db.UserProfiles.Add(userProfile);
                    db.SaveChanges();
                    return View(db.UserProfiles.Find(userId));
                }
                else
                {
                    db.Entry(userP).State = EntityState.Modified;
                    db.Entry(userP).CurrentValues.SetValues(userProfile);
                    db.SaveChanges();
                    return View(db.UserProfiles.Find(userId));
                }
            }
            

            return View(userProfile);
        }
    }
}
