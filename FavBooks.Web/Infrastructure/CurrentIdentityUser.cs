using FavBooks.Core;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavBooks.Web.Infrastructure
{
    public class CurrentIdentityUser :ICurrentUser
    {
        public string getUserId() {
            if (HttpContext.Current.User.Identity.IsAuthenticated) {
                return HttpContext.Current.User.Identity.GetUserId();
            }
            return null;
        }
    }
}