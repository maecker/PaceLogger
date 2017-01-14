using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Console {
    public class ConvertFitToTcx {       

        public static void Directory(string inputDir, string outputDir) {            

            var files = System.IO.Directory.GetFiles(inputDir, "*.fit");

            foreach(var source in files) {
                var f = new System.IO.FileInfo(source);                
                var target = f.Name.Replace(f.Extension, ".tcx");
                target = System.IO.Path.Combine(outputDir, target);
                File(source, target);
            }
        }

        public static void File(string inputPathFit, string outputPathTcx) {
            inputPathFit = inputPathFit.Replace('\\', '/');
            outputPathTcx = outputPathTcx.Replace('\\', '/');

            // gpsbabel -i garmin_fit -f "E:/_Incoming/ACTIVITY/6A3A2017.FIT" -o gtrnctr -F "E:/_Incoming/ACTIVITY/6A3A2017.TCX"
            var p = new Process();
            p.StartInfo.UseShellExecute = false;            
            p.StartInfo.FileName = @"C:\Program Files (x86)\GPSBabel\gpsbabel.exe";
            p.StartInfo.Arguments = $"-t -i garmin_fit -f {inputPathFit} -o gtrnctr -F {outputPathTcx}";
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            System.Console.WriteLine(outputPathTcx);
        }

    }
}
