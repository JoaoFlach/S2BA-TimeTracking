using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeTracking.MVC.Models;

namespace TimeTracking.MVC.Controllers
{
    public class WorkerActivitiesController : Controller
    {
        private EntitiesContext db = new EntitiesContext();

        // GET: WorkerActivities
        public ActionResult Index()
        {
            var workerActivities = db.WorkerActivities.Include(w => w.Activity).Include(w => w.Worker);
            return View(workerActivities.ToList());
        }

        // GET: WorkerActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerActivity workerActivity = db.WorkerActivities.Find(id);
            if (workerActivity == null)
            {
                return HttpNotFound();
            }
            return View(workerActivity);
        }

        // GET: WorkerActivities/Create
        public ActionResult Create()
        {
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name");
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name");
            return View();
        }

        // POST: WorkerActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerActivityID,WorkerID,ActivityID,HoursSpent,Date")] WorkerActivity workerActivity)
        {
            if (ModelState.IsValid)
            {
                db.WorkerActivities.Add(workerActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name", workerActivity.ActivityID);
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", workerActivity.WorkerID);
            return View(workerActivity);
        }

        // GET: WorkerActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerActivity workerActivity = db.WorkerActivities.Find(id);
            if (workerActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name", workerActivity.ActivityID);
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", workerActivity.WorkerID);
            return View(workerActivity);
        }

        // POST: WorkerActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerActivityID,WorkerID,ActivityID,HoursSpent,Date")] WorkerActivity workerActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name", workerActivity.ActivityID);
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", workerActivity.WorkerID);
            return View(workerActivity);
        }

        // GET: WorkerActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerActivity workerActivity = db.WorkerActivities.Find(id);
            if (workerActivity == null)
            {
                return HttpNotFound();
            }
            return View(workerActivity);
        }

        // POST: WorkerActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerActivity workerActivity = db.WorkerActivities.Find(id);
            db.WorkerActivities.Remove(workerActivity);
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
