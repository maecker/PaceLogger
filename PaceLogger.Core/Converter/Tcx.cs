using PaceLogger.Core.Serialization;
using PaceLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PaceLogger.Core.Converter {
    internal static class Tcx {
        public static Activity Activity(Activity_t a) {            

            return new Activity {
                Sport = Sport(a.Sport),
                Laps = Laps(a.Lap).ToArray()
            };
        }

        private static Sport Sport(Sport_t s) {
            switch(s) {
                case Sport_t.Running:
                case Sport_t.running:
                    return Model.Sport.Running;
                case Sport_t.Biking:
                case Sport_t.cycling:
                    return Model.Sport.Cycling;
                default:
                    throw new Exception(s.ToString());
            }
        }

        private static IEnumerable<Lap> Laps(ActivityLap_t[] laps) {
            foreach (ActivityLap_t lap in laps) {
                yield return Lap(lap);
            }
        }

        private static Lap Lap(ActivityLap_t lap) {
            return new Lap {
                AverageHeartRate = lap.AverageHeartRateBpm?.Value,
                Calories = (short)lap.Calories,
                DistanceMeters = lap.DistanceMeters,
                MaximumHeartRate = lap.MaximumHeartRateBpm?.Value,
                MaximumSpeed = lap.MaximumSpeedSpecified ? lap.MaximumSpeed : default(double?),
                StartTime = lap.StartTime.ToLocalTime(),
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
                Longitude = t.Position?.LongitudeDegrees,
                Time = t.Time.ToLocalTime()
            };
        }
    }
}
