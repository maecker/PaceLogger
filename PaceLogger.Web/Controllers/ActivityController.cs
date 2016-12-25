using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

namespace PaceLogger.Web.Controllers {
    public class ActivityController : Controller {

        [Route("activity/{id}")]
        public ActionResult Index(int id) {
            ViewBag.ActivityId = id;
            ViewBag.GoogleMapsKey = System.IO.File.ReadAllText(@"D:\Visual Studio 2015\GoogleMapsKey.txt");
            return View();
        } 
    }
}