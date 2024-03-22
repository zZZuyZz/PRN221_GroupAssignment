using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO.Models;
using Service.IService;

namespace UI.Pages.Projects
{
    public class InvestorCreateProjectProductsModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IProductService _productService;

        public InvestorCreateProjectProductsModel(IProjectService projectService ,IProductService productService)
        {
            _projectService = projectService;
            _productService = productService;
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
            Project.Id = Guid.NewGuid();
            //wating for userId from session login
            Project.InvestorId = Guid.Parse(HttpContext.Session.GetString("Id"));

            Project.ProjectStatus = "Chờ duyệt";
            Project.CreatedAt = DateTime.Now;

            _projectService.CreateProject(Project);

            foreach (var product in Products)
            {
                product.Id = Guid.NewGuid();
                product.ProjectId = Project.Id; // Assign projectId to products

                // waiting for userid from session login
                product.InvestorId = Guid.Parse(HttpContext.Session.GetString("Id"));

                product.CreatedAt = DateTime.Now;

                _productService.CreateProduct(product);
            };

            //waiting for return page
            return RedirectToPage("./ProjectsList");
        }
    }
}
