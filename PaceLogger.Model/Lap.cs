using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaceLogger.Model
{
    public class Lap {
        [Key]
        public int Id { get; set; }        

        public DateTime StartTime { get; set; }
        public double DistanceMeters { get; set; }
        public double? MaximumSpeed { get; set; }
        public short Calories { get; set; }
        public byte? AverageHeartRate { get; set; }
        public byte? MaximumHeartRate { get; set; }
        public Trackpoint[] Track { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
