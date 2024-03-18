using BO.Models;

namespace Service.IService;

public interface IProjectService
{
    Project? GetById(Guid projectId);
    public bool CreateProject(Project? project);
}
