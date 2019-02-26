using System.Web;
using System.Web.Optimization;

namespace InvestMent.Api
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Lib/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Lib/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Lib/angular.js",
                "~/Scripts/Lib/angular-route.js",
                "~/Scripts/Lib/angular-local-storage.js"));


            var bundle = new ScriptBundle("~/bundles/module");
            bundle.IncludeDirectory("~/Scripts/src/modules/", "*.js", true);
            bundles.Add(bundle);

            bundle = new ScriptBundle("~/bundles/app");
            bundle.IncludeDirectory("~/Scripts/src/services/", "*.js", true);
            bundle.IncludeDirectory("~/Scripts/src/components/", "*.js", true);
            bundle.IncludeDirectory("~/Scripts/src/config/", "*.js", true);
            bundle.IncludeDirectory("~/Scripts/src/directives/", "*.js", true);
            bundle.IncludeDirectory("~/Scripts/src/interceptors/", "*.js", true);
          

            bundles.Add(bundle);
        }
    }
}
