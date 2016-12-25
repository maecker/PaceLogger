using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaceLogger.Model;

namespace PaceLogger.Web.Controllers.Api {
    public class ActivityController : ApiController {

        [HttpGet]
        [Route("api/activity/{activityId}/laps")]        
        public Lap[] Laps(int activityId) {
            return Core.Repository.Laps.GetByActivityId(activityId);            
        }

        [HttpGet]
        [Route("api/activity/{activityId}/map")]        
        public GeoLocation[] Map(int activityId) {

            var trackpoints = Core.Repository.Trackpoints.GetByActivityId(activityId);
            return Core.Converter.Trackpoints.GeoLocations(trackpoints);            
        }

        [HttpGet]
        [Route("api/activity/{activityId}/chart")]        
        public ChartDataItem[] Chart(int activityId) {
            var trackpoints = Core.Repository.Trackpoints.GetByActivityId(activityId);
            return Core.Converter.Trackpoints.ChartData(trackpoints);
        }
    }
}