using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region IncidentsDashboardCore.JS scripts

            #region Datatables

            bundles.Add(new ScriptBundle("~/IDCore.JS/Datatables/userTable").Include(
                        "~/IncidentsDashboardCore.JS/Datatables/userTable.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Datatables/incidentTable").Include(
                        "~/IncidentsDashboardCore.JS/Datatables/incidentTable.js"));

            #endregion

            #region Common

            bundles.Add(new ScriptBundle("~/IDCore.JS/Common/LoadModalForm").Include(
                        "~/IncidentsDashboardCore.JS/Common/LoadModalForm.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Common/CloseModalEventHandler").Include(
                        "~/IncidentsDashboardCore.JS/Common/CloseModalEventHandler.js"));
            
            bundles.Add(new ScriptBundle("~/IDCore.JS/Common/SelectPickerHandler").Include(
                        "~/IncidentsDashboardCore.JS/Common/SelectPickerHandler.js"));


            #endregion

            #region Dashboard Controller's Views

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Dashboard/GetCreateAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Dashboard/GetCreateAsync.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Dashboard/GetDetailsAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Dashboard/GetDetailsAsync.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Dashboard/GetUpdateAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Dashboard/GetUpdateAsync.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Dashboard/GetUploadFileAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Dashboard/GetUploadFileAsync.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Dashboard/GetExportAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Dashboard/GetExportAsync.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Dashboard/GetDeleteAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Dashboard/GetDeleteAsync.js"));

            #endregion

            #region Admin Controller's Views

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Admin/GetCreateAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Admin/GetCreateAsync.js"));

            bundles.Add(new ScriptBundle("~/IDCore.JS/Views/Admin/GetUpdateAsync").Include(
                        "~/IncidentsDashboardCore.JS/Views/Admin/GetUpdateAsync.js"));

            #endregion

            #region Sammy.JS routing layout

            bundles.Add(new ScriptBundle("~/IDCore.JS/routing").Include(
                        "~/IncidentsDashboardCore.JS/layout-routing.js"));

            #endregion

            #endregion

            #region Libraries and Plugins

            #region Bootstrap Select

            bundles.Add(new StyleBundle("~/Content/bootstrap-select").Include(
                               "~/lib/bootstrap-select/dist/css/bootstrap-select.css",
                               "~/lib/bootstrap-select/dist/css/bootstrap-select.min.css"
                               ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select").Include(
                                       "~/lib/bootstrap-select/dist/js/bootstrap-select.js",
                                       "~/lib/bootstrap-select/dist/js/bootstrap-select.min.js"
                                       ));

            #endregion

            #region jQuery ContextMenu

            bundles.Add(new StyleBundle("~/Content/jqueryContextMenu").Include(
                               //"~/font/context-menu-icons.eot",
                               //"~/font/context-menu-icons.ttf",
                               //"~/font/context-menu-icons.woff",
                               //"~/font/context-menu-icons.woff2",

                               "~/Content/jquery.contextMenu.css",
                               "~/Content/jquery.contextMenu.min.css"
                               ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryContextMenu").Include(
                                       "~/Scripts/jquery.contextMenu.js",
                                       "~/Scripts/jquery.contextMenu.min.js",

                                       "~/Scripts/jquery.ui.position.js",
                                       "~/Scripts/jquery.ui.position.min.js"
                                       ));

            #endregion

            #region Sammy.JS

            bundles.Add(new ScriptBundle("~/bundles/sammyjs").Include(
            "~/Scripts/sammy.js/sammy*"));

            #endregion

            #region Datatables
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                "~/Content/dataTables.bootstrap5.css",
                "~/Content/dataTables.bootstrap5.min.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/dataTables.js",
                "~/Scripts/dataTables.min.js",
                "~/Scripts/dataTables.bootstrap5.js",
                "~/Scripts/dataTables.bootstrap5.min.js",
                "~/Scripts/dataTables.select.js",
                "~/Scripts/dataTables.select.min.js"
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
                      "~/Scripts/bootstrap.js",
                      //"~/Scripts/bootstrap.js.map",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap.bundle.js",
                      //"~/Scripts/bootstrap.bundle.js.map",
                      "~/Scripts/bootstrap.bundle.min.js"
                      ));

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
