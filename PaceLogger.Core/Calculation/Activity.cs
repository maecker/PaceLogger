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

    }
}
