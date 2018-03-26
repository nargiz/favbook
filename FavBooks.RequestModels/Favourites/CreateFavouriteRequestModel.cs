using System.ComponentModel.DataAnnotations;

namespace FavBooks.RequestModels.Favourites
{
    public class CreateFavouriteRequestModel
    {
        /// <summary>
        /// Book ISBN in ISBN13 format
        /// </summary>
        [Required]
        public long ISBN { get; set; }
    }
}
