using System;
using System.Linq;

namespace PaceLogger.Core.Repository {
    public class Activities {

        public static void Insert(Model.Activity a) {
            using (var db = new DatabaseContext()) {
                a = db.Activities.Add(a);                
                db.SaveChanges();
                
                foreach (var lap in a.Laps) {
                    lap.ActivityId = a.Id;
                    db.Laps.Add(lap);             
                }
                db.SaveChanges();

                foreach (var lap in a.Laps) { 
                    foreach(var trackpoint in lap.Track) {
                        trackpoint.LapId = lap.Id;
                        db.Trackpoints.Add(trackpoint);
                    }
                }
                db.SaveChanges();
            }
        }

        public static Model.Activity[] Get() {
            using (var db = new DatabaseContext()) {
                return db.Activities.ToArray();
            }
        }
    }
}
