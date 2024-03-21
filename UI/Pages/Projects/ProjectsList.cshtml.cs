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
    public class CustomerProjectsListModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        public CustomerProjectsListModel(IProjectService projectService, IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
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
    }
}
