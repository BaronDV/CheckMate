using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckMate.Models;

namespace CheckMate.Controllers
{

    [CustomAuthorize (Roles = "admin")]


    public class CourseCodeRefsController : Controller
    {
        private CheckMateDataEntities db = new CheckMateDataEntities();

        // GET: CourseCodeRefs
        public ActionResult Index()
        {
            return View(db.CourseCodeRefs.ToList());
        }

        // GET: CourseCodeRefs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCodeRef courseCodeRef = db.CourseCodeRefs.Find(id);
            if (courseCodeRef == null)
            {
                return HttpNotFound();
            }
            return View(courseCodeRef);
        }

        // GET: CourseCodeRefs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseCodeRefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseCodeRefID,CourseCodeName")] CourseCodeRef courseCodeRef)
        {
            if (ModelState.IsValid)
            {
                db.CourseCodeRefs.Add(courseCodeRef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseCodeRef);
        }

        // GET: CourseCodeRefs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCodeRef courseCodeRef = db.CourseCodeRefs.Find(id);
            if (courseCodeRef == null)
            {
                return HttpNotFound();
            }
            return View(courseCodeRef);
        }

        // POST: CourseCodeRefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseCodeRefID,CourseCodeName")] CourseCodeRef courseCodeRef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseCodeRef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseCodeRef);
        }

        // GET: CourseCodeRefs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCodeRef courseCodeRef = db.CourseCodeRefs.Find(id);
            if (courseCodeRef == null)
            {
                return HttpNotFound();
            }
            return View(courseCodeRef);
        }

        // POST: CourseCodeRefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseCodeRef courseCodeRef = db.CourseCodeRefs.Find(id);
            db.CourseCodeRefs.Remove(courseCodeRef);
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
