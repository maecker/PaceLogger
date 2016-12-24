using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceLogger.Model
{
    public class Trackpoint { 
        public DateTime Time { get; set; }
        public double? AltitudeMeters { get; set; }
        public double? DistanceMeters { get; set; }
        public byte? Heartrate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int LapId { get; set; }
        public int TrackpointId { get; set; }
    }
}
