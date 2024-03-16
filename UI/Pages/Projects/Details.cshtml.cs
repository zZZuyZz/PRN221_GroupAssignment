using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;

namespace UI.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Project? Project { get; set; }
        
        private readonly IProjectService service;

        public DetailsModel(IProjectService service)
        {
            this.service = service;
        }

        public IActionResult OnGet(string projectId)
        {
            try
            {
                Guid guid = Guid.Parse(projectId);
                Project = service.GetById(guid);
                if (Project == null)
                {
                    return RedirectToPage("/Error");
                }
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
