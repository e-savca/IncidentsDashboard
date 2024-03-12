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
            
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/datatables.net-bs5/*.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // adding datatables css
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                                     "~/Scripts/datatables.net-bs5/*.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      // set the custom theme
                      //"~/Content/bootstrap.css",
                      //"~/Content/bootstrap-yeti.css",
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));
        }
    }
}
