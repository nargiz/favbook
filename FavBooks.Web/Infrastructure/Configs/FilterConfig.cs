using System.Web;
using System.Web.Mvc;

namespace FavBooks.Web.Infrastructure.Configs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
