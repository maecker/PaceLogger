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
            var time = CalculateTime(t1, t2).Milliseconds;
            var distance = (t2.DistanceMeters.Value - t1.DistanceMeters.Value);
            return (distance / time) * 3600;
        }

        public static TimeSpan CalculateTime(Trackpoint t1, Trackpoint t2) {
            return (t2.Time - t1.Time);
        } 
    }    
}
