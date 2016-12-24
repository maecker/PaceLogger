using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Repository {
    public class Laps {

        public static Model.Lap[] GetByActivityId(int activityID) {

            using (var db = new DatabaseContext()) {
                var qr = from l in db.Laps
                         where l.ActivityId == activityID
                         orderby l.StartTime ascending
                         select l;
                return qr.ToArray();
            }
        }
    }
}
