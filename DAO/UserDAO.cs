using BO.Models;

namespace DAO
{
    public class UserDAO
    {
        private readonly RealEstateManagementContext _context = new();

        private static UserDAO _instance = new();

        public static UserDAO Instance
        {
            get
            {
                _instance ??= new UserDAO();
                return _instance;
            }
        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
