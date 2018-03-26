using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FavBooks.Core.Entities;
using FavBooks.Core.Repositories;

namespace FavBooks.DataAccess.Repositories
{
    class FavouriteRepository : Repository<Favourite>, IFavouriteRepository
    {
        public FavouriteRepository(FavBooksContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Favourite>> GetWithBookDetail(string userId, int pageNumber, int itemsPerPage)
        {
            return await Context.Set<Favourite>().Include(f=> f.Book).Where(f=>f.UserId == userId)
                .OrderByDescending(f=> f.DateCreated).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
        }

        public async Task<int> GetTotalItems(string userId)
        {
            return await Context.Set<Favourite>().Where(f => f.UserId == userId).CountAsync();
        }
    }
}
