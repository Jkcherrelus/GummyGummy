using GummyGummy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GummyGummy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//action methods, replacement of events.
        {
           
            
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult File()
        {

            return View("Contact");
        }
    }
}