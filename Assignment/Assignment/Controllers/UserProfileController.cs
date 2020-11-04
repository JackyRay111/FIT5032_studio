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

        //  GET the index page for user profile showing the details of user profile
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            UserProfile userProfile = db.UserProfiles.Find(userId);
            if (userProfile == null)
            {
                userProfile = new UserProfile();
                userProfile.Id = userId;
                userProfile.Email = db.AspNetUsers.Find(userId).Email;
            }
            return View(userProfile);
        }

        // GET the page for user to Edit profile
        [Authorize]
        public ActionResult EditAndCreate()
        {
            var userId = User.Identity.GetUserId();

           UserProfile userProfile = db.UserProfiles.Find(userId);
           if (userProfile == null)
           {
                userProfile = new UserProfile();
                userProfile.Id = userId;
                userProfile.Email = db.AspNetUsers.Find(userId).Email;
           }
           return View(userProfile);
        }

        // Post the user profile
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
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Entry(userP).State = EntityState.Modified;
                    db.Entry(userP).CurrentValues.SetValues(userProfile);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            

            return View();
        }
    }
}
