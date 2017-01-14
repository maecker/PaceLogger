using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Console {
    public class ImportTcxInDatabase {

        public static void Directory(string path, int userId) {
            var files = System.IO.Directory.GetFiles(path, "*.tcx");

            foreach (var source in files) {
                File(source, userId);
            }

            var directories = System.IO.Directory.GetDirectories(path);
            foreach(var dir in directories) {
                Directory(dir, userId);
            }
        }

        public static void File(string path, int userId) {

            var activity = Core.Serialization.TcxSerializer.Deserialize(path);
            activity.UserId = userId;

            Core.Repository.Activities.Insert(activity);

        }
    }
}
