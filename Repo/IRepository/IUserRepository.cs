using BO.Models;

namespace Repo.IRepository
{
    public interface IUserRepository
    {
        User? GetById(Guid id);
        User? GetByEmail(string email);
        bool Regiter(User? user);
        bool checkLogin(string email, string password);
    }
}
