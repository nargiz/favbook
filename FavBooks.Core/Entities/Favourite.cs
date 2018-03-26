using System;

namespace FavBooks.Core.Entities
{
    public class Favourite
    {
        public long ISBN { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public Book Book { get; set; }

        public Favourite()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
