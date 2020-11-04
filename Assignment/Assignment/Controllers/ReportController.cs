using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Assignment.Controllers
{
	public class ReportController : Controller
	{
		private AssignmentModel db = new AssignmentModel();
		
		// GET the page of the personal report
		public ActionResult Report()
			{
				var userId = User.Identity.GetUserId();
				List<DataPoint> dataPoints = new List<DataPoint>();
				ViewBag.Total = db.JoinLogs.Where(a => a.AspNetUserId == userId).Count();

				var course = db.JoinLogs.Where(a => a.Activity.ActivityTypeId == 1 && a.AspNetUserId == userId).Count();
				var qe = db.JoinLogs.Where(a => a.Activity.ActivityTypeId == 2 && a.AspNetUserId == userId).Count();
				var events = db.JoinLogs.Where(a => a.Activity.ActivityTypeId == 3 && a.AspNetUserId == userId).Count();

				dataPoints.Add(new DataPoint(course, "Course", "#E7823A"));
				dataPoints.Add(new DataPoint(qe, "Qulitifying Examination", "#546BC1"));
				dataPoints.Add(new DataPoint(events, "Event", "#99cc00"));

				ViewBag.Reports = JsonConvert.SerializeObject(dataPoints);

				dataPoints = new List<DataPoint>();
				dataPoints.Add(new DataPoint("FreeStyle", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 1 && a.Activity.ActivityTypeId == 1 && a.AspNetUserId ==userId).Count()));
				dataPoints.Add(new DataPoint("BackStorke", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 2 && a.Activity.ActivityTypeId == 1 && a.AspNetUserId == userId).Count()));
				dataPoints.Add(new DataPoint("Breaststroke", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 3 && a.Activity.ActivityTypeId == 1 && a.AspNetUserId == userId).Count()));
				dataPoints.Add(new DataPoint("Butterfly", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 4 && a.Activity.ActivityTypeId == 1 && a.AspNetUserId == userId).Count()));
				

				ViewBag.Course = JsonConvert.SerializeObject(dataPoints);

				dataPoints = new List<DataPoint>();
				dataPoints.Add(new DataPoint("FreeStyle", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 1 && a.Activity.ActivityTypeId == 2 && a.AspNetUserId == userId).Count()));
				dataPoints.Add(new DataPoint("BackStorke", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 2 && a.Activity.ActivityTypeId == 2 && a.AspNetUserId == userId).Count()));
				dataPoints.Add(new DataPoint("Breaststroke", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 3 && a.Activity.ActivityTypeId == 2 && a.AspNetUserId == userId).Count()));
				dataPoints.Add(new DataPoint("Butterfly", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 4 && a.Activity.ActivityTypeId == 2 && a.AspNetUserId == userId).Count()));

				ViewBag.QE = JsonConvert.SerializeObject(dataPoints);

				dataPoints = new List<DataPoint>();
				dataPoints.Add(new DataPoint("Party", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 5 && a.Activity.ActivityTypeId == 3 && a.AspNetUserId == userId).Count()));
				dataPoints.Add(new DataPoint("FreeSwimming", db.JoinLogs.Where(a => a.Activity.ActivityCategoryId == 6 && a.Activity.ActivityTypeId == 3 && a.AspNetUserId == userId).Count()));
			

				ViewBag.Events = JsonConvert.SerializeObject(dataPoints);

			return View();
			}
		}
	}
	

