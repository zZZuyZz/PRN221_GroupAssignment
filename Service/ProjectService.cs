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

        public Project? GetById(Guid projectId)
        {
            Project? project = projectRepository.GetById(projectId);
            if (project == null)
            {
                return null;
            }
            project.Investor = userRepository.GetById((Guid)project.InvestorId!);
            project.Products = productRepository.GetByProjectId(projectId);
            return project;
        }
    }
}
