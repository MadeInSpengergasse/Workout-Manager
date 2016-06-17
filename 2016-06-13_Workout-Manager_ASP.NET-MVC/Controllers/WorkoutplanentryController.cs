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
    public class WorkoutplanentryController : Controller
    {
        private TechnikmarktEntities db = new TechnikmarktEntities();

        // GET: workoutplanentry
        public ActionResult Index()
        {
            var workoutplanentries = db.workoutplanentries.Include(w => w.user).Include(w => w.workout).Where(x => x.wpe_u_user == User.Identity.Name).ToList();
            return View(workoutplanentries.ToList());
        }

        // GET: workoutplanentry/Details/5
        // not sure if this works 
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workoutplanentry workoutplanentry = db.workoutplanentries.Find(id);

            if (workoutplanentry == null)
            {
                return HttpNotFound();
            }
            return View(workoutplanentry);
        }

        // GET: workoutplanentry/Create
        public ActionResult Create()
        {
            ViewBag.wpe_u_user = new SelectList(db.users, "u_name", "u_password");
            ViewBag.wpe_w_workout = new SelectList(db.workouts, "w_id", "w_name");
            return View();
        }

        // POST: workoutplanentry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wpe_id,wpe_w_workout,wpe_creationdate,wpe_scheduledate,wpe_repeat,wpe_u_user")] workoutplanentry workoutplanentry)
        {
            if (ModelState.IsValid)
            {
                workoutplanentry.wpe_creationdate = DateTime.Today;
                workoutplanentry.wpe_u_user = User.Identity.Name;

                db.workoutplanentries.Add(workoutplanentry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.wpe_u_user = new SelectList(db.users, "u_name", "u_password", workoutplanentry.wpe_u_user);
            ViewBag.wpe_w_workout = new SelectList(db.workouts, "w_id", "w_name", workoutplanentry.wpe_w_workout);
            return View(workoutplanentry);
        }

        // GET: workoutplanentry/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workoutplanentry workoutplanentry = db.workoutplanentries.Find(id);
            if (workoutplanentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.wpe_u_user = new SelectList(db.users, "u_name", "u_password", workoutplanentry.wpe_u_user);
            ViewBag.wpe_w_workout = new SelectList(db.workouts, "w_id", "w_name", workoutplanentry.wpe_w_workout);
            return View(workoutplanentry);
        }

        // POST: workoutplanentry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wpe_id,wpe_w_workout,wpe_creationdate,wpe_scheduledate,wpe_repeat,wpe_u_user")] workoutplanentry workoutplanentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workoutplanentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.wpe_u_user = new SelectList(db.users, "u_name", "u_password", workoutplanentry.wpe_u_user);
            ViewBag.wpe_w_workout = new SelectList(db.workouts, "w_id", "w_name", workoutplanentry.wpe_w_workout);
            return View(workoutplanentry);
        }

        // GET: workoutplanentry/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workoutplanentry workoutplanentry = db.workoutplanentries.Find(id);
            if (workoutplanentry == null)
            {
                return HttpNotFound();
            }
            return View(workoutplanentry);
        }

        // POST: workoutplanentry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            workoutplanentry workoutplanentry = db.workoutplanentries.Find(id);
            db.workoutplanentries.Remove(workoutplanentry);
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
