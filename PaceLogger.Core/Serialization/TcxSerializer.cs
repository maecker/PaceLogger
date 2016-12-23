using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PaceLogger.Core.Serialization {
    public class TcxSerializer {
        public static Model.Activity Deserialize(string pathTcxFile) {
            var data = loadTcx(pathTcxFile);
            return PaceLogger.Core.Converter.Tcx.Acitivty(data.Activities.Activity[0]); // TODO: z.Zt. Annahme das das TCX immer nur eine Activity hat, was aber laut XSD nicht stimmt           
        }

        private static TrainingCenterDatabase_t loadTcx(string pathTcxFile) {
            XmlSerializer xs = new XmlSerializer(typeof(TrainingCenterDatabase_t));
            TrainingCenterDatabase_t data;
            using (var fs = new FileStream(pathTcxFile, FileMode.Open)) {
                data = xs.Deserialize(fs) as TrainingCenterDatabase_t;
            }               

            return data;
        }
    }
}
