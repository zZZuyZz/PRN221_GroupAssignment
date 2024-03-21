using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService
    {
        public User? GetById(Guid id);
        public User? GetByEmail(string email);
        public bool Regiter(User user);
        public bool checkLogin(string email, string password);

    }
}
