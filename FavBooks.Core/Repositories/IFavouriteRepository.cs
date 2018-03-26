
using FavBooks.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavBooks.Core.Repositories
{
    public interface IFavouriteRepository : IRepository<Favourite>
    {
        Task<IEnumerable<Favourite>> GetWithBookDetail(string userId, int pageNumber, int itemsPerPage);
        Task<int> GetTotalItems(string userId);
    }
}
