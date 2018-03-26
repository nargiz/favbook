using FavBooks.Core;
using FavBooks.DataAccess;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace FavBooks.Web.Infrastructure.Configs
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICurrentUser, CurrentIdentityUser>();
            config.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}