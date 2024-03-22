using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO.Models;

namespace UI.Pages.Bookings
{
    public class lisstModel : PageModel
    {
        private readonly BO.Models.RealEstateManagementContext _context;

        public lisstModel(BO.Models.RealEstateManagementContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null)
            {
                Booking = await _context.Bookings
                .Include(b => b.Agency)
                .Include(b => b.Customer)
                .Include(b => b.Product).ToListAsync();
            }
        }
    }
}
