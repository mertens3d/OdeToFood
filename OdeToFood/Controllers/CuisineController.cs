using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Filters;

namespace OdeToFood.Controllers
{

     //  [Authorize]
    [Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        public ActionResult Search(string name = "french")
        {
            var message = Server.HtmlEncode(name);
            throw new Exception("Something terrible happened");
            return Content(message);
        }

    }
}
