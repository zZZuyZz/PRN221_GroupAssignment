using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IProductService
    {
        public bool CreateProduct(Product? product);
        public List<Product> GetByProjectId(Guid projectId);
        public Product? GetById(Guid id);
    }
}
