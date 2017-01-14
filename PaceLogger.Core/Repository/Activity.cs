using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                //db.Trackpoints.AddRange(lap.Track);


            }
        }
    }
}
