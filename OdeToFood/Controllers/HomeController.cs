using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {

        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {

            var model = _db.Restaurants.ToList();

            return View(model);
            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Gregory";
            model.Location = "Texas, USA";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
