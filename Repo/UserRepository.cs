using BO.Models;
using DAO;
using Repo.IRepository;

namespace Repo
{
    public class UserRepository : IUserRepository
    {
        public bool checkLogin(string email, string password) => UserDAO.Instance.checkLogin(email, password);

        public User? GetByEmail(string email) => UserDAO.Instance.GetByEmail(email);

        public User? GetById(Guid id) => UserDAO.Instance.GetById(id);

        public bool Regiter(User? user) => UserDAO.Instance.Regiter(user);
    }
}
