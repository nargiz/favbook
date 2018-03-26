using System.Web.Mvc;
using System.Web.Routing;

namespace FavBooks.Web.Infrastructure.Configs
{
    public class WebAppConfig
    {
        internal static void RegisterRoutes(RouteCollection routes)
        {
           routes.MapRoute("Angular", "{*anything}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}