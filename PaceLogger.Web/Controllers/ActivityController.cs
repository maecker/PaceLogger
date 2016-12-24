using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

namespace PaceLogger.Web.Controllers {
    public class ActivityController : Controller {

        [Route("laps")]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Laps() {

            var activity = Core.Serialization.TcxSerializer.Deserialize(@"D:\Visual Studio 2015\TrainingCenter\TCX-Resources\xml\activity_1485474501.tcx");
            var laps = activity.Laps.ToArray();

            return Json(laps, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index() {
            return View();
        }
    }
}