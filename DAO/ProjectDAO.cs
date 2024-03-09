using BO.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO;

public class ProjectDAO
{
    private readonly RealEstateManagementContext _context = new();

    private static ProjectDAO _instance = new();

    public static ProjectDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectDAO();
            }
            return _instance;
        }
    }

    public Project? GetById(int id, bool includeProducts = false)
    {
        return _context.Projects.Include(p => includeProducts ? p.Products : null)
                                .FirstOrDefault(p => p.Id.Equals(id));
    }
}
