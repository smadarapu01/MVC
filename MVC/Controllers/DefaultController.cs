using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewData["Countries"] = new List<string>()
            {
                "India",
                "USA",
                "UK",
                "China",
                "Canada"
            };

            return View();
        }
    }
}