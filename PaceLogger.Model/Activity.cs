using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaceLogger.Model
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }           

        public DateTime StartTime { get; set; }
        public TimeSpan Time { get; set; }
        public double DistanceMeters { get; set; }
        public TimeSpan Pace { get; set; }
        public byte? AverageHeartRate { get; set; }
        public double? AltitudeMeters { get; set; }
        public virtual Lap[] Laps { get; set; }
        public Sport? Sport { get; set; }
        public short? Calories { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
