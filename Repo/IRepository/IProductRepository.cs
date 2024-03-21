using BO.Models;

namespace Repo.IRepository
{
    public interface IProductRepository
    {
        Product? GetById(Guid id);

        List<Product> GetByProjectId(Guid projectId);
        public bool CreateProduct(Product? product);
    }
}
