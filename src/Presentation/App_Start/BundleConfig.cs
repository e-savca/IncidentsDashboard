using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/sammyjs").Include(
                        "~/Scripts/sammy.js/sammy*"));

            bundles.Add(new ScriptBundle("~/bundles/layout-routing").Include(
                        "~/Scripts/layout-routing.js"));

            // adding dataTables.js to the project
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/dataTables.dataTables.js",
                        "~/Scripts/dataTables.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/dataTables").Include(
                        "~/Content/dataTables.dataTables.css",
                        "~/Content/dataTables.dataTables.min.css"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // set custom theme
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));

            //// default theme
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
