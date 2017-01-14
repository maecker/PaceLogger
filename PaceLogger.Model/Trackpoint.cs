using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PaceLogger.Model
{
    public class Trackpoint {

        [Key]
        public int Id { get; set; }        

        public DateTime Time { get; set; }
        public double? AltitudeMeters { get; set; }
        public double? DistanceMeters { get; set; }
        public byte? Heartrate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        

        [ForeignKey("Lap")]
        public int LapId { get; set; }
        public Lap Lap { get; set; }



    }
}
