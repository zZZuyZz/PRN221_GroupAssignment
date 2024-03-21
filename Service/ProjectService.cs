using BO.Models;
using Repo.IRepository;
using Service.IService;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IUserRepository userRepository;
        private readonly IProductRepository productRepository;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
            this.productRepository = productRepository;
        }

        public bool ApproveProject(Guid id)
        {
            return projectRepository.ApproveProject(id);
        }

        public bool CreateProject(Project? project)
        {
            return projectRepository.CreateProject(project);
        }

        public Project? GetById(Guid projectId)
        {
            Project? project = projectRepository.GetById(projectId);
            if (project == null)
            {
                return null;
            }
            project.Products = productRepository.GetByProjectId(projectId);
            return project;
        }

        public List<Project>? GetByProjectTitle(string name)
        {
            return projectRepository.GetByProjectTitle(name);
        }

        public List<Project>? GetProjects()
        {
            return projectRepository.GetProjects();
        }

        public List<Project>? GetProjectsByInvestorId(Guid id)
        {
            return projectRepository.GetProjectsByInvestorId(id);
        }
    }
}
