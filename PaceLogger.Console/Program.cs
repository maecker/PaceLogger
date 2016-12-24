using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Console {
    class Program {
        static void Main(string[] args) {

            var activity = Core.Serialization.TcxSerializer.Deserialize(@"D:\Visual Studio 2015\TrainingCenter\TCX-Resources\xml\activity_1485474501.tcx");

            Core.Repository.Activities.Insert(activity);

        }
    }
}
