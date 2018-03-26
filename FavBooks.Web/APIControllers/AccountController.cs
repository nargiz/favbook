using System.Web.Http;
using FavBooks.Core;
using System.Web.Http.Description;
using FavBooks.RequestModels.Account;

namespace FavBooks.Web.APIControllers
{
    public class AccountController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Account/Register")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Register(CreateUserRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool succeeded = unitOfWork.Users.Register(model.UserName, model.Password);

            if (succeeded)
            {
                return Ok();
            }

            return BadRequest();
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
