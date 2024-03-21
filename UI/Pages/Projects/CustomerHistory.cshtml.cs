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
    public class CustomerHistoryModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IBookingService _bookingService;
        public CustomerHistoryModel(IProjectService projectService, IBookingService bookingService)
        {
            _projectService = projectService;
            _bookingService = bookingService;
        }

        public IList<Project> Project { get; set; } = default!;
        public IList<Booking> Booking { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Project = _projectService.GetProjectsByInvestorId(Guid.Parse(HttpContext.Session.GetString("Id")));

            Booking = _bookingService.GetBookingsByCustomerId(Guid.Parse(HttpContext.Session.GetString("Id")));
        }
    }
}
