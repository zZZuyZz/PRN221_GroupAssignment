using BO.Models;
using Repo.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProjectRepository _projectRepository;

        public ProductService(IProductRepository productRepository, IProjectRepository projectRepository)
        {
            _productRepository = productRepository;
            _projectRepository = projectRepository;
        }

        public bool CreateProduct(Product? product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product? GetById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetByProjectId(Guid projectId)
        {
            return _productRepository.GetByProjectId(projectId);
        }

        public Product? GetProductById(Guid id, bool includeProject = false)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            if (includeProject)
            {
                product.Project = _projectRepository.GetById((Guid)product.ProjectId!);
            }
            return product;
        }
    }
}
