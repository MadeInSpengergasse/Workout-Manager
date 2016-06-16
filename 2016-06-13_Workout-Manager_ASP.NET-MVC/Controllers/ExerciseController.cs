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
    public class ExerciseController : Controller
    {
        private TechnikmarktEntities db = new TechnikmarktEntities();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var exercises = from e in db.exercises
                            select e;
            switch (sortOrder)
            {
                case "name_desc":
                    exercises = exercises.OrderByDescending(e => e.e_name);
                    break;
                case "Date":
                    exercises = exercises.OrderBy(e => e.e_id);
                    break;
                case "date_desc":
                    exercises = exercises.OrderByDescending(e => e.e_id);
                    break;
                default:
                    exercises = exercises.OrderBy(e => e.e_name);
                    break;
            }
            return View(exercises.ToList());
        }
    }

}
