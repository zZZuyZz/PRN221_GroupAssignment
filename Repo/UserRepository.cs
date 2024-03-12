using BO.Models;
using DAO;
using Repo.IRepository;

namespace Repo
{
    public class UserRepository : IUserRepository
    {
        public User? GetById(Guid id)
        {
            return UserDAO.Instance.GetById(id);
        }
    }
}
