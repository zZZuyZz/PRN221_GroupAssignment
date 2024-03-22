using BO.Models;

namespace Repo.IRepository
{
    public interface IProjectRepository
    {
        Project? GetById(Guid id);
        public bool CreateProject(Project? project);
        List<Project>? GetProjects();
        List<Project>? GetProjectsByStatus();
        List<Project>? GetByProjectTitle(string name);
        List<Project>? GetProjectsByInvestorId(Guid id);
        public bool ApproveProject(Guid id);

    }
}
