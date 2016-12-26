using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PaceLogger.Web {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {

           

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/bower_components/jquery/dist/jquery.js",
                "~/bower_components/bootstrap/dist/js/bootstrap.js",
                "~/bower_components/react/react.js",
                "~/bower_components/react/react-dom.js",
                "~/bower_components/moment/moment.js",
                "~/bower_components/Chart.js/dist/Chart.js"));             

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.min.css"));
        }
    }
}