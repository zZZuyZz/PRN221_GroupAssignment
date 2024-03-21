using BO.Models;

namespace Service.IService;

public interface IProjectService
{
    Project? GetById(Guid projectId);
    public bool CreateProject(Project? project);
    public List<Project>? GetProjects();
    public List<Project>? GetByProjectTitle(string name);
    public List<Project>? GetProjectsByInvestorId(Guid id);
    public bool ApproveProject(Guid id);

}
