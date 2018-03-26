using FavBooks.DataAccess;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Routing;
using FavBooks.Web.Infrastructure.Configs;

[assembly: OwinStartup(typeof(FavBooks.Web.Startup))]

namespace FavBooks.Web
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static string PublicClientId { get; private set; }


        public Startup()
        {
            PublicClientId = "FavBooksWebApp";
        }
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AuthorizationConfig.RegisterOAuth(app);
            WebApiConfig.RegisterRoutes(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            WebAppConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents(config);
            SwaggerConfig.Register(config);

            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperConfig>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FavBooksContext, FavBooks.DataAccess.Migrations.Configuration>());

        }
      
       

    }
}