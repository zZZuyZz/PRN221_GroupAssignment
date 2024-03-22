using BO.Models;
using Repo.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool checkLogin(string email, string password)
        {
            return _repository.checkLogin(email, password);
        }

        public User? GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public User? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool Regiter(User? user)
        {
            user.RoleId = Guid.Parse("43090161-855A-4D9F-AC61-B4A2432A199E");
            user.IsActive = 1;
            user.CreatedAt = DateTime.Now;
            return _repository.Regiter(user);
        }
    }
}
