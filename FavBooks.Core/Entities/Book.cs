using System.Collections.Generic;

namespace FavBooks.Core.Entities
{
    public class Book
    {
        public long ISBN { get; set; }
        public string Title { get; set; }
        public string CoverThumb { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string Subjects { get; set; }
        public string Authors { get; set; }

        public virtual ICollection<Favourite> Favourites { get; set; }

    }
}
