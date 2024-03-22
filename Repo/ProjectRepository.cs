using BO.Models;
using DAO;
using Repo.IRepository;

namespace Repo
{
    public class ProjectRepository : IProjectRepository
    {
        public bool ApproveProject(Guid id) => ProjectDAO.Instance.ApproveProject(id);

        public bool CreateProject(Project? project) => ProjectDAO.Instance.CreateProject(project);

        public Project? GetById(Guid id) => ProjectDAO.Instance.GetById(id);

        public List<Project>? GetByProjectTitle(string name) => ProjectDAO.Instance.GetByProjectTitle(name);

        public List<Project>? GetProjects() => ProjectDAO.Instance.GetProjects();

        public List<Project>? GetProjectsByInvestorId(Guid id) => ProjectDAO.Instance.GetProjectsByInvestorId(id);

        public List<Project>? GetProjectsByStatus() => ProjectDAO.Instance.GetProjectsByStatus();
    }
}
