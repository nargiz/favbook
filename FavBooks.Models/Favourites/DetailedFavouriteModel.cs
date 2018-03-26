using FavBooks.Models.Books;
using System;

namespace FavBooks.Models.Favourites
{
    public class DetailedFavouriteModel : BookModel
    {
        /// <summary>
        /// Date and time when the book added to favourites (In UTC)
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
