using BO.Models;

namespace DAO
{
    public class ProjectDAO
    {
        private readonly RealEstateManagementContext _context = new();

        private static ProjectDAO _instance = new();

        public static ProjectDAO Instance
        {
            get
            {
                _instance ??= new ProjectDAO();
                return _instance;
            }
        }

        public Project? GetById(Guid id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
