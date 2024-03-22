using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO.Models;
using Service.IService;

namespace UI.Pages.Projects
{
    public class AgencyProjectDetailsModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IProductService _productService;

        public AgencyProjectDetailsModel(IProjectService projectService, IProductService productService)
        {
            _projectService = projectService;
            _productService = productService;
        }

        public Project Project { get; set; } = default!; 
        public IList<Product>? Products { get; set; }

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
                Products = _productService.GetByProjectId(id);
                Project = project;
            }
            return Page();
        }
    }
}
