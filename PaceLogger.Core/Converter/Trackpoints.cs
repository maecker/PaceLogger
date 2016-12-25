using PaceLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Converter {

    public static class Trackpoints {
        public static ChartDataItem[] ChartData(Trackpoint[] trackpoints) {
            var first = trackpoints[0];
            var result = new ChartDataItem[trackpoints.Length - 1];
            for (var i = 1; i < trackpoints.Length; i++) {
                var tp = trackpoints[i];
                result[i] = new ChartDataItem {
                    ElapsedSeconds = Calculation.Trackpoints.CalculateTime(first, tp).Seconds,
                    Speed = Calculation.Trackpoints.CalculateSpeed(trackpoints[i - 1], tp),
                    Heartrate = tp.Heartrate,
                    AltitudeMeters = tp.AltitudeMeters
                };
            }

            return result;
        }

        public static GeoLocation[] GeoLocations(Trackpoint[] trackpoints, int step = 1) {
            var result = new List<GeoLocation>();

            for (var i = 0; i < trackpoints.Length; i += step) {
                var tp = trackpoints[i];
                if (tp.Latitude.HasValue && tp.Longitude.HasValue) {
                    result.Add(new GeoLocation { Latitude = tp.Latitude.Value, Longitude = tp.Longitude.Value });
                }
            }

            return result.ToArray();
        }
    }
}
