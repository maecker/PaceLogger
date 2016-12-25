using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

namespace PaceLogger.Web.Controllers {
    public class ActivityController : Controller {

        [Route("activity/{id}")]
        public ActionResult Index(string id) {
            ViewBag.ActivityId = id;
            return View();
        }

        [Route("api/activity/{activityId}/laps")]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Laps(int activityId) {
            var laps = Core.Repository.Laps.GetByActivityId(activityId);
            return Json(laps, JsonRequestBehavior.AllowGet);
        }         

        [Route("api/activity/{activityId}/map")]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Map(int activityId) {

            var trackpoints = Core.Repository.Trackpoints.GetByActivityId(activityId);

            var result = new List<dynamic>();

            for (var i = 0; i < trackpoints.Length; i += 2) {
                var tp = trackpoints[i];
                result.Add(new { lat = tp.Latitude, lng = tp.Longitude });
            }            

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}