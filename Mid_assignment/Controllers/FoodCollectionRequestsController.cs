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
    public class FoodCollectionRequestsController : Controller
    {
        private Db_Connection db = new Db_Connection();

        // GET: FoodCollectionRequests
        public ActionResult Index()
        {
            var foodCollectionRequests = db.FoodCollectionRequests.Include(f => f.Restaurant);
            return View(foodCollectionRequests.ToList());
        }

        // GET: FoodCollectionRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCollectionRequest foodCollectionRequest = db.FoodCollectionRequests.Find(id);
            if (foodCollectionRequest == null)
            {
                return HttpNotFound();
            }
            return View(foodCollectionRequest);
        }

        // GET: FoodCollectionRequests/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name");
            return View();
        }

        // POST: FoodCollectionRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,RestaurantId,RequestTime,MaximumPreservationTime,CollectionStatus")] FoodCollectionRequest foodCollectionRequest)
        {
            if (ModelState.IsValid)
            {
                db.FoodCollectionRequests.Add(foodCollectionRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", foodCollectionRequest.RestaurantId);
            return View(foodCollectionRequest);
        }

        // GET: FoodCollectionRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCollectionRequest foodCollectionRequest = db.FoodCollectionRequests.Find(id);
            if (foodCollectionRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", foodCollectionRequest.RestaurantId);
            return View(foodCollectionRequest);
        }

        // POST: FoodCollectionRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,RestaurantId,RequestTime,MaximumPreservationTime,CollectionStatus")] FoodCollectionRequest foodCollectionRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodCollectionRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", foodCollectionRequest.RestaurantId);
            return View(foodCollectionRequest);
        }

        // GET: FoodCollectionRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCollectionRequest foodCollectionRequest = db.FoodCollectionRequests.Find(id);
            if (foodCollectionRequest == null)
            {
                return HttpNotFound();
            }
            return View(foodCollectionRequest);
        }

        // POST: FoodCollectionRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodCollectionRequest foodCollectionRequest = db.FoodCollectionRequests.Find(id);
            db.FoodCollectionRequests.Remove(foodCollectionRequest);
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
