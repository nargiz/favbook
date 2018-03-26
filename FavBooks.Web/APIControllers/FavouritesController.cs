using AutoMapper;
using FavBooks.Core;
using FavBooks.Core.Entities;
using FavBooks.Models.Favourites;
using FavBooks.RequestModels.Favourites;
using FavBooks.Web.Infrastructure.ActionFilters;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FavBooks.Web.APIControllers
{
    /// <summary>
    /// Manage user's favourites
    /// </summary>
    public class FavouritesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string userId;
        public FavouritesController(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            this.unitOfWork = unitOfWork;
            userId = currentUser.getUserId();
        }

        /// <summary>
        /// List favourited books
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="itemsPerPage">items per page</param>
        /// <returns>List of books</returns>
        [HttpGet]
        [Authorize]
        [Route("api/Favourites/{page?}/{itemsPerPage?}")]
        public async Task<HttpResponseMessage> GetAll(int page = 1, int itemsPerPage = 20)
        {
            int totalItems = await unitOfWork.Favourites.GetTotalItems(userId);
            IEnumerable<Favourite> favourites = await unitOfWork.Favourites.GetWithBookDetail(userId, page, itemsPerPage);
            PagedFavouritesModel response = new PagedFavouritesModel()
            {
                Total = totalItems,
                Items = favourites.Select(f => Mapper.Map<DetailedFavouriteModel>(f))
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Create favourite entry for the book
        /// </summary>
        /// <param name="request">Request details such as ISBN</param>
        /// <returns>No content</returns>
        [HttpPost]
        [Authorize]
        [LoggingFilter]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.Conflict, "Specified book is already in favourite list")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book could not be recognized")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Could not save the data")]
        [SwaggerResponseRemoveDefaults]
        [Route("api/Favourites")]
        public async Task<HttpResponseMessage> Create([FromBody]CreateFavouriteRequestModel request)
        {
            Favourite existingFavourite = await unitOfWork.Favourites.Get(userId, request.ISBN);
            if (existingFavourite != null)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
            Book book = await unitOfWork.Books.Get(request.ISBN);
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            unitOfWork.Favourites.Add(new Favourite() { Book = book, UserId = userId});
            bool succeeded = await unitOfWork.Complete();

            if (!succeeded)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Delete book from favourites list
        /// </summary>
        /// <param name="ISBN">ISBN of the book</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [LoggingFilter]
        [SwaggerResponse(HttpStatusCode.NoContent, "Item deleted")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book could not be recognized")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Could not delete the data")]
        [SwaggerResponseRemoveDefaults]
        [Route("api/Favourites/{ISBN}")]
        public async Task<HttpResponseMessage> Delete([FromUri]long ISBN)
        {
            Favourite existingFavourite = await unitOfWork.Favourites.Get(userId, ISBN);
            if (existingFavourite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            unitOfWork.Favourites.Remove(existingFavourite);
            bool succeeded = await unitOfWork.Complete();

            if (!succeeded)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
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