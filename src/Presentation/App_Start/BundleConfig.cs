﻿using Castle.Components.DictionaryAdapter.Xml;
using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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


            bundles.Add(new ScriptBundle("~/dataTablesAjax/GetUsersList").Include(
                        "~/Scripts/dataTablesAjax/GetUsersList.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/sammyjs").Include(
                        "~/Scripts/sammy.js/sammy*"));

            bundles.Add(new ScriptBundle("~/bundles/layout-routing").Include(
                        "~/Scripts/IncidentsDashboardCore/layout-routing.js"));


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

            BundleTable.EnableOptimizations = true;
        }
    }
}
