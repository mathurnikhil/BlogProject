using System.Web;
using System.Web.Optimization;

namespace owin_1
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/material-kit.css",
                      "~/Content/material-kit.css",
                      "~/Content/material-kit.css.map",
                      "~/Content/login-dropdown.css"));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
               "~/Scripts/material-kit.js",
               "~/Scripts/material.min.js",
               "~/Scripts/nouislider.min.js",
               "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/myjsfiles").Include(
                        "~/Scripts/custom-jsfunctions.js"));
        }
    }
}
