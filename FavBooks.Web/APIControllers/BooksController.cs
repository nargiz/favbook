using AutoMapper;
using FavBooks.Core;
using FavBooks.Core.Entities;
using FavBooks.Models.Books;
using FavBooks.Web.Infrastructure.ActionFilters;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FavBooks.Web.APIControllers
{
    /// <summary>
    /// Find a book
    /// </summary>
    public class BooksController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the information about book by its ISBN
        /// </summary>
        /// <param name="ISBN">Books ISBN</param>
        /// <returns>Details of the book</returns>
        [Authorize]
        [ResponseType(typeof(BookModel))]
        [LoggingFilter]
        [SwaggerResponse(HttpStatusCode.NotFound, "Could not find a book")]
        [Route("api/Books/{ISBN}")]
        public async Task<HttpResponseMessage> Get([FromUri]long ISBN)
        {
            Book book = await unitOfWork.Books.Get(ISBN);

            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<BookModel>(book));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (unitOfWork != null)
                {
                    unitOfWork.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}