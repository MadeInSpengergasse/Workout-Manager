using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2016_06_13_Workout_Manager_ASP.NET_MVC.Models;
using PagedList;

namespace _2016_06_13_Workout_Manager_ASP.NET_MVC.Controllers
{
    public class ExerciseController : Controller
    {
        private TechnikmarktEntities db = new TechnikmarktEntities();

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var exercises = from e in db.exercises
                            select e;

            if (searchString != null) {
                page = 1;
            } else { searchString = currentFilter; }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString)) {
                exercises = exercises.Where(s => s.e_name.ToUpper().Contains(searchString.ToUpper()));
            }

                switch (sortOrder) {
                case "name_desc":
                    exercises = exercises.OrderByDescending(e => e.e_name);
                    break;
                default:
                    exercises = exercises.OrderBy(e => e.e_name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(exercises.ToPagedList(pageNumber, pageSize));
        }
    }

}
