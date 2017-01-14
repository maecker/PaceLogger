using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

namespace PaceLogger.Web.Controllers {
    public class ActivitiesController : Controller {

        [Route("activities")]
        public ActionResult List() {            
            return View();
        }

        [Route("activities/{id}")]
        public ActionResult Detail(int id) {
            ViewBag.ActivityId = id;
            ViewBag.GoogleMapsKey = System.IO.File.ReadAllText(@"D:\Visual Studio 2015\GoogleMapsKey.txt");
            return View();
        } 
    }
}