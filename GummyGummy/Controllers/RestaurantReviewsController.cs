using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GummyGummy.Models;
using Microsoft.AspNet.Identity;

namespace GummyGummy.Controllers
{
    public class RestaurantReviewsController : Controller
    {
        private RestaurantDB db = new RestaurantDB();

        // GET: RestaurantReviews
        public ActionResult Index(int? id)
        {
           
            var reviews = db.Reviews.Include(r => r.Restaurant).Where(m => id == m.Restaurant.Id);
            return View(reviews.ToList());
        }
        

        // GET: RestaurantReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name");
            return View();
        }

        // POST: RestaurantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles ="User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rating,Comment,DateRated,RestaurantId")] RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                restaurantReview.UserID = User.Identity.GetUserId();
                db.Reviews.Add(restaurantReview);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Edit/5
        [Authorize(Roles = "User,Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Admin")]
        public ActionResult Edit([Bind(Include = "Id,Rating,Comment,DateRated,RestaurantId")] RestaurantReview restaurantReview)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return View(restaurantReview);
            }

            var userId = User.Identity.GetUserId();

            if (ModelState.IsValid && userId == restaurantReview.UserID)
            {
                db.Entry(restaurantReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            db.Reviews.Remove(restaurantReview);
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
