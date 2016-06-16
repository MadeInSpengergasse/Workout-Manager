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
    public class UserController : Controller
    {
        private TechnikmarktEntities db = new TechnikmarktEntities();

        // GET: user/Details/5
        public ActionResult Details()
        {
            user user = db.users.Find(User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: user/Edit/5
        public ActionResult Edit()
        {
            user user = db.users.Find(User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_name,u_password,u_age,u_height,u_weight")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(user);
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
