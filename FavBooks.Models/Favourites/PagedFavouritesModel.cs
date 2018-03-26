
using System.Collections.Generic;

namespace FavBooks.Models.Favourites
{
    public class PagedFavouritesModel
    {
        public int Total { get; set; }
        public IEnumerable<DetailedFavouriteModel> Items { get; set; }
    }
}
