using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceLogger.Model
{
    public class Lap {
        public DateTime StartTime { get; set; }
        public double DistanceMeters { get; set; }
        public double? MaximumSpeed { get; set; }
        public ushort Calories { get; set; }
        public byte? AverageHeartRate { get; set; }
        public byte? MaximumHeartRate { get; set; }
        public Trackpoint[] Track { get; set; }
        public int ActivityId { get; set; }
        public int LapId { get; set; }
    }
}
