using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO.Models;

namespace UI.Pages.Projects
{
    public class InvestorCreateProjectProductsModel : PageModel
    {
        private readonly BO.Models.RealEstateManagementContext _context;

        public InvestorCreateProjectProductsModel(BO.Models.RealEstateManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = new List<Product> { new Product() }; // Add an initial product
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            foreach (var product in Products)
            {
                product.ProjectId = Project.Id; // Assign projectId to products
                _context.Products.Add(product);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        public void AddProduct()
        {
            Products.Add(new Product());
        }
    }
}
