using PaceLogger.Core.Serialization;
using PaceLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PaceLogger.Core.Converter {
    internal static class Tcx {
        public static Activity Acitivty(Activity_t a) {
            return new Activity {
                Laps = Laps(a.Lap).ToArray()
            };
        }

        private static IEnumerable<Lap> Laps(ActivityLap_t[] laps) {
            foreach (ActivityLap_t lap in laps) {
                yield return Lap(lap);
            }
        }

        private static Lap Lap(ActivityLap_t lap) {
            return new Lap {
                AverageHeartRate = lap.AverageHeartRateBpm?.Value,
                Calories = lap.Calories,
                DistanceMeters = lap.DistanceMeters,
                MaximumHeartRate = lap.MaximumHeartRateBpm?.Value,
                MaximumSpeed = lap.MaximumSpeedSpecified ? lap.MaximumSpeed : default(double?),
                StartTime = lap.StartTime,
                Track = Trackpoints(lap.Track).ToArray()
            };
        }

        private static IEnumerable<Trackpoint> Trackpoints(Trackpoint_t[] trackpoints) {
            foreach (Trackpoint_t trackpoint in trackpoints) {
                yield return Trackpoint(trackpoint);
            }
        }

        private static Trackpoint Trackpoint(Trackpoint_t t) {
            return new Trackpoint {
                AltitudeMeters = t.AltitudeMetersSpecified ? t.AltitudeMeters : default(double?),
                DistanceMeters = t.DistanceMetersSpecified ? t.DistanceMeters : default(double?),
                Heartrate = t.HeartRateBpm?.Value,
                Latitude = t.Position?.LatitudeDegrees,
                Longitude = t.Position?.LatitudeDegrees,
                Time = t.Time
            };
        }
    }
}
