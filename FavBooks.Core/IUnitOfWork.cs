using FavBooks.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace FavBooks.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IFavouriteRepository Favourites { get; }
        IUserRepository Users { get; }

        Task<bool> Complete();
    }
}
