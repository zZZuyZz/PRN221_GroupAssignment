using BO.Models;
using DAO;
using Repo.IRepository;

namespace Repo
{
    public class ProjectRepository : IProjectRepository
    {
        public Project? GetById(Guid id) => ProjectDAO.Instance.GetById(id);
    }
}
