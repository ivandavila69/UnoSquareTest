using System.Web;
using System.Web.Optimization;

namespace UnoSquareTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bower_components/lodash/lodash.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-csp.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap.min.js",
                        "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-tpls.js",
                        "~/Scripts/App/app.js",
                        "~/Scripts/App/services/boardGameService.js",
                        "~/Scripts/App/controllers/boardGameCtrl.js",
                        "~/Scripts/App/controllers/editBoardGameCtrl.js",
                        "~/Scripts/App/controllers/addBoardGameCtrl.js",
                        "~/Scripts/App/controllers/deleteBoardGameCtrl.js"));
        }
    }
}
