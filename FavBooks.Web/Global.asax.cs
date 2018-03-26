using FavBooks.Web.Infrastructure.Configs;
using System.Web.Mvc;
using System.Web.Optimization;

namespace FavBooks.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }

    }
}
