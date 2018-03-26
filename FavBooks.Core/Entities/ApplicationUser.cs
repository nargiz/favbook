using FavBooks.Core;
using FavBooks.Core.Entities;
using System.Collections.Generic;

namespace FavBooks.DataAccess
{
    public partial class ApplicationUser
    {
        public virtual ICollection<Favourite> Favourites { get; set;  }
    }
}
