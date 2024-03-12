using BO.Models;

namespace Repo.IRepository
{
    public interface IProjectRepository
    {
        Project? GetById(Guid id);
    }
}
