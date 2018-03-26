namespace FavBooks.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<FavBooks.DataAccess.FavBooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FavBooks.DataAccess.FavBooksContext context)
        {
          
        }
        
    }
}
