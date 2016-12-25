using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Repository {
    public class Trackpoints {

        public static Model.Trackpoint[] GetByActivityId(int activityID) {

            const string SQL = @"
                SELECT * 
                FROM dbo.Trackpoints 
                WHERE LapId IN (SELECT LapId FROM Laps WHERE ActivityId = @p0)";

            using (var db = new DatabaseContext()) {
                var tp = db.Trackpoints.SqlQuery(SQL, activityID);
                return tp.ToArray();
            }
        }
    }
}
