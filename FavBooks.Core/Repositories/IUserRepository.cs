
namespace FavBooks.Core.Repositories
{
    public interface IUserRepository
    {
        bool Register(string userName, string password);
        string ValidateCredentials(string userName, string password);
    }
}
