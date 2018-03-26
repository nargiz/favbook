using FavBooks.Web.WebHelpers;
using System.Web;
using System.Web.Optimization;

namespace FavBooks.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/jsbundles/libs").Include(
                     "~/Scripts/angular.js"
                    , "~/Scripts/angular-animate.js"
                    , "~/Scripts/angular-route.js"
                    , "~/Scripts/angular-sanitize.js"
                    , "~/Scripts/loading-bar.js"
                    , "~/Scripts/jquery-{version}.js"
                    , "~/Scripts/bootstrap.js"
                    , "~/Scripts/angular-local-storage.js"
                    , "~/Scripts/dirPagination.js"
                    , "~/Scripts/angular-confirm.js"
                    , "~/Scripts/angular-ui/ui-bootstrap.js"
                    , "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                    , "~/bower_components/ngToast/dist/ngToast.js"
                ));

            bundles.Add(new ScriptBundle("~/jsbundles/main").Include(
                           "~/app/app.js"
                           )
                           .IncludeDirectory("~/app/directives", "*.js", true)
                           .IncludeDirectory("~/app/services", "*.js", true)
                           .IncludeDirectory("~/app/controllers", "*.js", true)
                           );

            bundles.Add(new StyleBundle("~/content/libbundle").Include(
                 "~/Content/bootstrap.css"
                , "~/Content/font-awesome.css"
                , "~/Content/loading-bar.css"
                , "~/bower_components/ngToast/dist/ngToast.css"
                , "~/bower_components/ngToast/dist/ngToast-animations.css"
                ));

            bundles.Add(new StyleBundle("~/content/mainbundle").Include(
                "~/Content/site.css"
               ));

            bundles.Add(new AngularTemplateBundle("~/bundles/templates", "FavBooksApp")
               .Include("~/app/views/home.html")
               .Include("~/app/views/orders.html")
               .Include("~/app/views/refresh.html")
               .Include("~/app/views/tokens.html")
               .Include("~/app/views/account/*.html")
               );

        }
    }
}
