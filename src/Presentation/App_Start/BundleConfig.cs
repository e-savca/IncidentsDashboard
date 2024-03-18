using Castle.Components.DictionaryAdapter.Xml;
using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region IncidentsDashboardCore.JS scripts

            #region Admin Controller

            bundles.Add(new ScriptBundle("~/IDCore.JS/Admin/Index").Include(
                        "~/IncidentsDashboardCore.JS/Views/Admin/Index.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Admin/GetCreate").Include(
                        "~/IncidentsDashboardCore.JS/Views/Admin/GetCreate.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Admin/GetEditAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Admin/GetEditAsync.js"));

            #endregion

            #region Sammy.JS routing layout

            bundles.Add(new ScriptBundle("~/IDCore.JS/routing").Include(
                        "~/IncidentsDashboardCore.JS/layout-routing.js"));

            #endregion

            #endregion

            #region Libraries and Plugins

            #region jQuery ContextMenu

            //bundles.Add(new StyleBundle("~/Content/jqueryContextMenu").Include(
            //                   "~/Scripts/jquery-contextmenu/font/context-menu-icons.eot",
            //                   "~/Scripts/jquery-contextmenu/font/context-menu-icons.ttf",
            //                   "~/Scripts/jquery-contextmenu/font/context-menu-icons.woff",
            //                   "~/Scripts/jquery-contextmenu/font/context-menu-icons.woff2",

            //                   "~/Scripts/jquery-contextmenu/jquery.contextMenu.css",
            //                   "~/Scripts/jquery-contextmenu/jquery.contextMenu.min.css",
            //                   "~/Scripts/jquery-contextmenu/jquery.contextMenu.min.css.map"
            //                   ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryContextMenu").Include(
            //                           "~/Scripts/jquery-contextmenu/jquery.contextMenu.js",
            //                           "~/Scripts/jquery-contextmenu/jquery.contextMenu.min.js",
            //                           "~/Scripts/jquery-contextmenu/jquery.contextMenu.min.js.map",

            //                           "~/Scripts/jquery-contextmenu/jquery.ui.position.js",
            //                           "~/Scripts/jquery-contextmenu/jquery.ui.position.min.js"
            //                           ));

            #endregion

            #region Sammy.JS

            bundles.Add(new ScriptBundle("~/bundles/sammyjs").Include(
            "~/Scripts/sammy.js/sammy*"));

            #endregion

            #region Datatables
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                "~/Content/dataTables.dataTables.css",
                "~/Content/dataTables.dataTables.min.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/dataTables.js",
                "~/Scripts/dataTables.min.js",
                "~/Scripts/dataTables.dataTables.js",
                "~/Scripts/dataTables.dataTables.min.js"
                ));

            #endregion

            #endregion

            #region Default Bundles

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

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

            #endregion

            // Set EnableOptimizations to false for debugging. Allow to use bundles in debug mode
            BundleTable.EnableOptimizations = true;
        }
    }
}
