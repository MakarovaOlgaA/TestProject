using System.Web.Optimization;

namespace BookCataloque
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/base-bundle").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout-mapping.js",
                        "~/Scripts/Extensions/ko-custom-bindings.js",
                        "~/Scripts/global-settings.js"));

            bundles.Add(new ScriptBundle("~/bundles/ko-validation").Include(
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/Extensions/ko-validation-rules.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/select2.min.css"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                     "~/Content/css/select2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/book-search").Include(
                      "~/Scripts/Books/book-grid.js",
                      "~/Scripts/Books/book-filter.js",
                      "~/Scripts/Books/book-editor.js",
                      "~/Scripts/select2.js"));

            bundles.Add(new ScriptBundle("~/bundles/authors-search").Include());
        }
    }
}
