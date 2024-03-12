using BO.Models;
using DAO;
using Repo.IRepository;

namespace Repo
{
    public class ProductRepository : IProductRepository
    {
        public Product? GetById(Guid id)
        {
            return ProductDAO.Instance.GetById(id);
        }

        public List<Product> GetByProjectId(Guid projectId)
        {
            return ProductDAO.Instance.GetByProjectId(projectId);
        }
    }
}
