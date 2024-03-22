using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO.Models;
using Service.IService;
using System.Runtime.CompilerServices;

namespace UI.Pages.Projects
{
    public class CustomerProjectDetailsModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IProductService _productService;

        public CustomerProjectDetailsModel(IProjectService projectService, IProductService productService)
        {
            _productService = productService;
            _projectService = projectService;
        }

        public Project Project { get; set; } = default!;
        public List<Product> Products { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            else 
            {
                Project = project;
                var products = _productService.GetByProjectId(project.Id);
                Products = products;
            }
            return Page();
        }
    }
}
