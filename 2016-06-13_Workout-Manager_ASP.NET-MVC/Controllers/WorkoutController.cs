using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2016_06_13_Workout_Manager_ASP.NET_MVC.Models;

namespace _2016_06_13_Workout_Manager_ASP.NET_MVC.Controllers
{
    public class WorkoutController : Controller
    {
        private TechnikmarktEntities db = new TechnikmarktEntities();

        // GET: workout
        public ActionResult Index()
        {
            return View(db.workouts.ToList());
        }
    }
}
