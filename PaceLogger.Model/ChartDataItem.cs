using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Model {
    public class ChartDataItem {
        public double ElapsedSeconds { get; set; }
        public double? Speed { get; set; }
        public byte? Heartrate { get; set; }
        public double? AltitudeMeters { get; set; }
    }
}
