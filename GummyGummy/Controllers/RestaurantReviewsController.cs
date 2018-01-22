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
            ViewBag.RestaurantName = db.Restaurants.SingleOrDefault(r => r.Id == restaurantReview.RestaurantId).Name;
            if (restaurantReview == null)
            {
                return HttpNotFound();
            }


            return View(restaurantReview);
        }

        // GET: RestaurantReviews/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();//gets the user id
            if(userId == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name");
            return View();
        }

        // POST: RestaurantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rating,Comment,DateRated,RestaurantId")] RestaurantReview restaurantReview)
        {
            

            var userId = User.Identity.GetUserId();//gets the user id
            if (userId == null)
            {
                return RedirectToAction("Index","RestaurantReviewsController");
            }
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
        public ActionResult Edit(int? id)
        {
            
            var userId = User.Identity.GetUserId();//gets the user id
            RestaurantReview restaurantReview = db.Reviews.Find(id);
            if(!string.Equals(userId,restaurantReview.UserID))//checks if the user is correct
            {
                //sends you to the login page
                return RedirectToAction("Login", "Account");
            }
            if (restaurantReview == null )
            {
                return HttpNotFound();
            }


            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", restaurantReview.RestaurantId);
            return View(restaurantReview);
        }

        // POST: RestaurantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rating,Comment,DateRated,RestaurantId")] RestaurantReview restaurantReview)
        {

            if (ModelState.IsValid )//checks that the user matches the id
            {
                //is used to get the current user id
                var userId = User.Identity.GetUserId();
                restaurantReview.UserID = userId;
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
