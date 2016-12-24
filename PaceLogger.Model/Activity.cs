using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceLogger.Model
{
    public class Activity
    {        
        public int ActivityId { get; set; }
        public int UserId { get; set; }        
        public DateTime StartTime { get; set; }
        public TimeSpan Time { get; set; }
        public double DistanceMeters { get; set; }
        public virtual Lap[] Laps { get; set; }
    }
}
