using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

namespace PaceLogger.Web.Controllers {
    public class ActivityController : Controller {

        [Route("api/laps/{activityId}")]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Laps(string activityId) {  
            var laps = Core.Repository.Laps.GetByActivityId(int.Parse(activityId));
            return Json(laps, JsonRequestBehavior.AllowGet);
        }

        [Route("activity/{id}")]
        public ActionResult Index(string id) {
            ViewBag.ActivityId = id;
            return View();
        }
    }
}