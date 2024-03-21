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
        public User? GetByEmail(string email) 
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);

        }
        public bool checkLogin(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Regiter(User? user)
        {
            bool result = false;
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
    }
}
