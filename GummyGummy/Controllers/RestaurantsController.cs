using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GummyGummy.Models;
using GummyGummy.Custom_Filters;

namespace GummyGummy.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantDB db = new RestaurantDB();



        // GET: Restaurants
        //public ActionResult Index()
        //{
        //    db.Restaurants.Include(m => m.Review);
        //    return View(db.Restaurants.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : " ";
            ViewBag.RateSortParm = sortOrder == "Rate" ? "rate_desc" : "rate";
            var restaurant = db.Restaurants.Include(m => m.Review);
            
            if(!String.IsNullOrEmpty(searchString))
            {
                restaurant = restaurant.Where(m => m.Name.Contains(searchString) || 
                                m.Address.City.Contains(searchString) ||
                                m.Address.ZipCode.Contains(searchString) ||
                                m.Address.State.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    restaurant = restaurant.OrderByDescending(m => m.Name);
                    break;
                case "rate_desc":
                    restaurant = restaurant.OrderByDescending(m => m.AvgRating);
                    break;
                case "rate":
                    restaurant = restaurant.OrderBy(m => m.AvgRating);
                    break;
                default:
                    break;
            }

            return View(restaurant.ToList());
        }


        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);//find by Primary key
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        [Authorize(Roles ="Admin")]
        [Log]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Street,City,State,Country,ZipCode,Phone,Email,Address")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Street,City,State,Country,ZipCode,Phone,Email,Address")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
