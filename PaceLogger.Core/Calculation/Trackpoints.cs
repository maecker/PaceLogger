using PaceLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Calculation {
    internal class Trackpoints {

        /// <summary>
        /// Geschwindikeit in km/h ermitteln
        /// </summary>
        /// <param name="t1">der erste Trackpoint (zeitlich vor t2)</param>
        /// <param name="t2">der zweite Trackpoint (zeitlich nach t1)</param>
        /// <returns></returns>
        public static double? CalculateSpeed(Trackpoint t1, Trackpoint t2) {
            if (!t2.DistanceMeters.HasValue || !t1.DistanceMeters.HasValue) {
                return null;
            }
            var time = CalculateTime(t1, t2).TotalMilliseconds;
            var distance = (t2.DistanceMeters.Value - t1.DistanceMeters.Value);
            return (distance / time) * 3600;
        }

        public static TimeSpan CalculateTime(Trackpoint t1, Trackpoint t2) {
            return (t2.Time - t1.Time);
        }

        public static double CalculateMaximumSpeed(Trackpoint[] tp) {
            var maxSpeed = 0D;
            for (var i = 1; i < tp.Length; i++) {
                var speed = CalculateSpeed(tp[i - 1], tp[i]) ?? 0;
                if (speed > maxSpeed) {
                    maxSpeed = speed;
                }
            }
            return maxSpeed;
        }

        public static byte CalculateMaximumHeartRate(Trackpoint[] trackpoints) {
            var max = (byte)0;
            foreach(var tp in trackpoints) {
                var hr = tp.Heartrate ?? 0;
                if (hr > max) {
                    hr = max;
                }
            }
            return max;
        }

        public static byte? CalculateAverageHeartRate(Trackpoint[] trackpoints) {
            int count = 0, sum = 0;
            foreach (var tp in trackpoints) {
                if (tp.Heartrate.HasValue) {
                    count++;
                    sum += tp.Heartrate.Value;
                }                
            }
            return count > 0 ? (byte)(sum / count) : default(byte?);
        }
    }    
}
