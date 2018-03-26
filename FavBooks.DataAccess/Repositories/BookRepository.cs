
using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FavBooks.Core;
using FavBooks.Core.Entities;
using FavBooks.Core.Repositories;
using Newtonsoft.Json.Linq;

namespace FavBooks.DataAccess.Repositories
{
    class BookRepository : Repository<Book>, IBookRepository
    {
        private  IExternalDataProvider<Book> bookProvider{ get; set; }
        public BookRepository(FavBooksContext context, IExternalDataProvider<Book> bookProvider) : base(context)
        {
            this.bookProvider = bookProvider;
        }

        public async override Task<Book> Get(params Object[] keys)
        {
            Book book = await base.Get(keys);
            if(book == null)
            {
                book = await bookProvider.GetItem(keys);
            }
            return book;
        }

    }
}
