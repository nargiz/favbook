using FavBooks.Core;
using FavBooks.Core.Repositories;
using FavBooks.DataAccess.ExternalDataProviders;
using FavBooks.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace FavBooks.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FavBooksContext context;
        public IBookRepository Books { get; private set; }
        public IFavouriteRepository Favourites { get; private set; }

        public IUserRepository Users { get; private set; }

        public UnitOfWork(FavBooksContext context)
        {
            this.context = context;
            Books = new BookRepository(context, new BookDataProvider());
            Favourites = new FavouriteRepository(context);
            Users = new UserRepository(context);
        }

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
