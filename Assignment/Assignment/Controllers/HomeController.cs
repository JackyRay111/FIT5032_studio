using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using Assignment.Utils;
using System.IO;

namespace Assignment.Controllers
{
    
    [RequireHttps]
    public class HomeController : Controller
    {
        private AssignmentModel db = new AssignmentModel();

        // Get the homepage
        public ActionResult Index()
        {
            return View();
        }

        // Get the about page
        public ActionResult About()
        {
            return View();
        }

        // Get the contact page
        public ActionResult Contact()
        {

            return View();
        }

        // Get the send_Email page
        [Authorize(Roles = "Administrator")]
        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        // Post sent the bulk email to all user
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model, HttpPostedFileBase postedFile)
        {
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            var myPath = myUniqueFileName;
            if (ModelState.IsValid)
            {
                try
                {
                    List<String> toEmail = db.AspNetUsers.Select(a => a.Email).ToList();
                    String subject = model.Subject;
                    String contents = model.Contents;
                    string serverPath = Server.MapPath("~/Uploads/");
                    string fileExtension = Path.GetExtension(postedFile.FileName);
                    string filePath = myPath + fileExtension;
                    myPath = filePath;
                    postedFile.SaveAs(serverPath + myPath);
                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents, serverPath + myPath);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }
    }
}