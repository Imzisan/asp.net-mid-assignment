using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mid_assignment.EF;
using Mid_assignment.EF.Models;

namespace Mid_assignment.Controllers
{
    public class CollectionAssignmentsController : Controller
    {
        private Db_Connection db = new Db_Connection();

        // GET: CollectionAssignments
        public ActionResult Index()
        {
            var collectionAssignments = db.CollectionAssignments.Include(c => c.Employee).Include(c => c.FoodCollectionRequest);
            return View(collectionAssignments.ToList());
        }

        // GET: CollectionAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionAssignment collectionAssignment = db.CollectionAssignments.Find(id);
            if (collectionAssignment == null)
            {
                return HttpNotFound();
            }
            return View(collectionAssignment);
        }

        // GET: CollectionAssignments/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId");
            return View();
        }

        // POST: CollectionAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignmentId,RequestId,EmployeeId,AssignedTime")] CollectionAssignment collectionAssignment)
        {
            if (ModelState.IsValid)
            {
                db.CollectionAssignments.Add(collectionAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", collectionAssignment.EmployeeId);
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId", collectionAssignment.RequestId);
            return View(collectionAssignment);
        }

        // GET: CollectionAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionAssignment collectionAssignment = db.CollectionAssignments.Find(id);
            if (collectionAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", collectionAssignment.EmployeeId);
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId", collectionAssignment.RequestId);
            return View(collectionAssignment);
        }

        // POST: CollectionAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentId,RequestId,EmployeeId,AssignedTime")] CollectionAssignment collectionAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectionAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", collectionAssignment.EmployeeId);
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId", collectionAssignment.RequestId);
            return View(collectionAssignment);
        }

        // GET: CollectionAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionAssignment collectionAssignment = db.CollectionAssignments.Find(id);
            if (collectionAssignment == null)
            {
                return HttpNotFound();
            }
            return View(collectionAssignment);
        }

        // POST: CollectionAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollectionAssignment collectionAssignment = db.CollectionAssignments.Find(id);
            db.CollectionAssignments.Remove(collectionAssignment);
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
