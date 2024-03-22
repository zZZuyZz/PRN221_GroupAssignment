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
    public class AgencyViewProjectListModel : PageModel
    {
        private readonly IProjectService _projectService;

        public AgencyViewProjectListModel(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [BindProperty]
        public string SearchKey { get; set; }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Project = _projectService.GetProjects();
        }
        public IActionResult OnPost()
        {
            if (SearchKey == null)
            {
                Project = _projectService.GetProjects();
                return Page();
            }
            else
            {
                Project = new List<Project>();
                Project = _projectService.GetByProjectTitle(SearchKey);
            }

            return Page();
        }
        public IActionResult OnPostOnApprove(Guid id)
        {
            _projectService.ApproveProject(id);

            Project = _projectService.GetProjects();
            return Page();
        }
    }
}
