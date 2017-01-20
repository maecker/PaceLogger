using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Calculation {
    public class Lap {

        public static Model.Lap[] Split(Model.Lap lap, double distanceInMetersPerLap) {
                        
            double lapStartsWithDistance = 0;
            List<Model.Trackpoint> trackpoints = null;
            var laps = new List<Model.Lap>();

            foreach (var t in lap.Track) {
                if (trackpoints == null) {
                    trackpoints = new List<Model.Trackpoint>();
                }                

                trackpoints.Add(t);
                var d = t.DistanceMeters.Value;

                if (d > lapStartsWithDistance + distanceInMetersPerLap) {
                    var tp = trackpoints.ToArray();
                    laps.Add(new Model.Lap {
                        Track = tp,
                        DistanceMeters = (d - lapStartsWithDistance),
                        StartTime = tp.First().Time,
                        MaximumSpeed = Calculation.Trackpoints.CalculateMaximumSpeed(tp),
                        AverageHeartRate = Calculation.Trackpoints.CalculateAverageHeartRate(tp),
                        MaximumHeartRate = Calculation.Trackpoints.CalculateMaximumHeartRate(tp)                        
                    });                    
                    lapStartsWithDistance = d;
                    trackpoints = null;
                }
            }

            var calories = lap.Calories / laps.Count();
            foreach(var l in laps) {
                l.Calories = (short)calories;
            }

            return laps.ToArray();
        }
    }
}
