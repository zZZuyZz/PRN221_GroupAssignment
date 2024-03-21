using BO.Models;

namespace DAO
{
    public class ProductDAO
    {
        private readonly RealEstateManagementContext _context = new();

        private static ProductDAO _instance = new();

        public static ProductDAO Instance
        {
            get
            {
                _instance ??= new ProductDAO();
                return _instance;
            }
        }

        public Product? GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetByProjectId(Guid projectId)
        {
            return _context.Products.Where(p => p.ProjectId == projectId).ToList();
        }
        public bool CreateProduct(Product? booking)
        {
            bool result = false;
            try
            {
                _context.Products.Add(booking);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
    }
}
