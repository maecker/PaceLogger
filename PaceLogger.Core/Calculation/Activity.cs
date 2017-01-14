using PaceLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Calculation {
    internal class Activity {

        public static TimeSpan CalculateTotalTime (Lap[] laps) {
            var startTime = laps.First().StartTime;
            var endTime = laps.Last().Track.Last().Time;
            return  endTime.Subtract(startTime);
        }

        public static double CalculateTotalDistance(Lap[] laps) {
            double total = 0;
            foreach(Lap lap in laps) {
                total += lap.DistanceMeters;
            }
            return total;
        }        

        public static TimeSpan CalculatePace(TimeSpan time, double distanceMeters) {
            return new TimeSpan((long)(time.Ticks / (distanceMeters / 1000)));
        }

        public static double CalulateTotalAltitudeMeters(Lap[] laps) {
            double summe = 0;
            foreach (Lap lap in laps) {

                for(var i=1; i < lap.Track.Length; i++) {
                    var tp1 = lap.Track[i - 1].AltitudeMeters;
                    var tp2 = lap.Track[i].AltitudeMeters;
                    var alt1 = tp1.HasValue ? tp1.Value : 0;
                    var alt2 = tp2.HasValue ? tp2.Value : 0;
                    if (alt1 > 0 && alt2 > 0 && alt2 > alt1) {
                        summe += (alt2 - alt1);
                    }
                }
            }
            return summe;
        }

        public static byte? CalulateTotalAverageHeartrate(Lap[] laps) {
            int total = 0, items = 0;
            foreach (Lap lap in laps) {
                foreach (Trackpoint tp in lap.Track) {
                    if (tp.Heartrate.HasValue) {
                        total += tp.Heartrate.Value;
                        items++;
                    }
                }
            }
            if (total == 0) return null;
            return (byte)(total / items);
        }
    }
}
