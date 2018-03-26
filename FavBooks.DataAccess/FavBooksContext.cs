using FavBooks.Core.Entities;
using FavBooks.DataAccess.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FavBooks.DataAccess
{
    public class FavBooksContext : IdentityDbContext<IdentityUser>
    {
        public FavBooksContext()
            : base("FavBooksContext")
        {
     
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new FavouriteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

}