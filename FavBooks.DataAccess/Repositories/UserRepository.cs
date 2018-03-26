using FavBooks.Core.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavBooks.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly DbContext Context;
        private readonly UserManager<IdentityUser> userManager;
        public UserRepository(FavBooksContext context)
        {
            Context = context;
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

        }
        public bool Register(string userName, string password)
        {
            IdentityUser newUser = new IdentityUser() { UserName = userName };
            var result = userManager.Create(newUser, password);
            return result.Succeeded;
        }

        public string ValidateCredentials(string userName, string password)
        {
            IdentityUser user = userManager.Find(userName, password);
            return user.Id;
        }
    }
}
