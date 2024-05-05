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

    [CustomAuthorize (Roles ="admin,enduser")]


    public class TaskDetailsController : Controller
    {
        private CheckMateDataEntities db = new CheckMateDataEntities();

        // GET: TaskDetails
        public ActionResult Index()
        {
            var taskDetails = db.TaskDetails.Include(t => t.CourseCodeRef);
            return View(taskDetails.ToList());
        }

        // GET: TaskDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDetail taskDetail = db.TaskDetails.Find(id);
            if (taskDetail == null)
            {
                return HttpNotFound();
            }
            return View(taskDetail);
        }

        // GET: TaskDetails/Create
        public ActionResult Create()
        {
            ViewBag.CourseCodeID = new SelectList(db.CourseCodeRefs, "CourseCodeRefID", "CourseCodeName");
            return View();
        }

        // POST: TaskDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskDescription,CourseCodeID,Remarks")] TaskDetail taskDetail)
        {
            if (ModelState.IsValid)
            {
                db.TaskDetails.Add(taskDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseCodeID = new SelectList(db.CourseCodeRefs, "CourseCodeRefID", "CourseCodeName", taskDetail.CourseCodeID);
            return View(taskDetail);
        }

        // GET: TaskDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDetail taskDetail = db.TaskDetails.Find(id);
            if (taskDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseCodeID = new SelectList(db.CourseCodeRefs, "CourseCodeRefID", "CourseCodeName", taskDetail.CourseCodeID);
            return View(taskDetail);
        }

        // POST: TaskDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskDescription,CourseCodeID,Remarks")] TaskDetail taskDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseCodeID = new SelectList(db.CourseCodeRefs, "CourseCodeRefID", "CourseCodeName", taskDetail.CourseCodeID);
            return View(taskDetail);
        }

        // GET: TaskDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDetail taskDetail = db.TaskDetails.Find(id);
            if (taskDetail == null)
            {
                return HttpNotFound();
            }
            return View(taskDetail);
        }

        // POST: TaskDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskDetail taskDetail = db.TaskDetails.Find(id);
            db.TaskDetails.Remove(taskDetail);
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
