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
    public class FoodDistributionsController : Controller
    {
        private Db_Connection db = new Db_Connection();

        // GET: FoodDistributions
        public ActionResult Index()
        {
            var foodDistributions = db.FoodDistributions.Include(f => f.FoodCollectionRequest);
            return View(foodDistributions.ToList());
        }

        // GET: FoodDistributions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDistribution foodDistribution = db.FoodDistributions.Find(id);
            if (foodDistribution == null)
            {
                return HttpNotFound();
            }
            return View(foodDistribution);
        }

        // GET: FoodDistributions/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId");
            return View();
        }

        // POST: FoodDistributions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistributionId,RequestId,DistributionTime")] FoodDistribution foodDistribution)
        {
            if (ModelState.IsValid)
            {
                db.FoodDistributions.Add(foodDistribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId", foodDistribution.RequestId);
            return View(foodDistribution);
        }

        // GET: FoodDistributions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDistribution foodDistribution = db.FoodDistributions.Find(id);
            if (foodDistribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId", foodDistribution.RequestId);
            return View(foodDistribution);
        }

        // POST: FoodDistributions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistributionId,RequestId,DistributionTime")] FoodDistribution foodDistribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodDistribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.FoodCollectionRequests, "RequestId", "RequestId", foodDistribution.RequestId);
            return View(foodDistribution);
        }

        // GET: FoodDistributions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDistribution foodDistribution = db.FoodDistributions.Find(id);
            if (foodDistribution == null)
            {
                return HttpNotFound();
            }
            return View(foodDistribution);
        }

        // POST: FoodDistributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodDistribution foodDistribution = db.FoodDistributions.Find(id);
            db.FoodDistributions.Remove(foodDistribution);
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
