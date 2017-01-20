using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Console {
    class Program {
        static void Main(string[] args) {

            //ConvertFitToTcx.Directory(@"E:\_Incoming\ACTIVITY", @"E:\_Incoming\CONVERTED_TCX");
            //ImportTcxInDatabase.Directory(@"E:\_Incoming\CONVERTED_TCX", 1);

            ImportTcxInDatabase.Directory(@"D:\TCX", 1);

            System.Console.ReadLine();
        }

        private static void test () {
            var activity = Core.Serialization.TcxSerializer.Deserialize(@"D:\Visual Studio 2015\TrainingCenter\TCX-Resources\xml\activity_1485474501.tcx");
            activity.UserId = 1;

            //  Core.Repository.Activities.Insert(activity);
        }
    }
}
