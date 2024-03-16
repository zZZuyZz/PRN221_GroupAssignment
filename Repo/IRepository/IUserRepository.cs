using BO.Models;

namespace Repo.IRepository
{
    public interface IUserRepository
    {
        User? GetById(Guid id);
    }
}
