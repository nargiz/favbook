using System;
using System.Threading.Tasks;

namespace FavBooks.Core
{
    public interface IExternalDataProvider<TEntity>
    {
        Task<TEntity> GetItem(params Object[] keys);
    }
}
