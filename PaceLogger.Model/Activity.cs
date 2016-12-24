using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceLogger.Model
{
    public class Activity
    {  
        public DateTime StartTime { get; set; }
        public TimeSpan Time { get; set; }
        public double DistanceMeters { get; set; }
        public Lap[] Laps { get; set; }
    }
}
