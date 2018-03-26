using FavBooks.Core;
using FavBooks.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Unity;

namespace FavBooks.Web.Infrastructure
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string publicClientId;
        public SimpleAuthorizationServerProvider(string publicClientId)
        {
            this.publicClientId = publicClientId;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(publicClientId);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            UnityContainer container = new UnityContainer();
            var unitOfWork = container.Resolve<UnitOfWork>();

            string userId = unitOfWork.Users.ValidateCredentials(context.UserName, context.Password);

            if (userId == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.GivenName, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));

            context.Validated(identity);

        }

    }
}