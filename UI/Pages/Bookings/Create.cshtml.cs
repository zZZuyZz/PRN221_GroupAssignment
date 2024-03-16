using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO.Models;

namespace UI.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly BO.Models.RealEstateManagementContext _context;

        public CreateModel(BO.Models.RealEstateManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Guid? productId)
        {
          if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
            {
                return Page();
            }
            Booking.Id = Guid.NewGuid();
            Booking.CreatedAt = DateTime.Now;
            Booking.CreatedBy = Guid.NewGuid().ToString();
            Booking.Status = "InProgress"; // You can set the status to "InProgress" here

            // Example: Get userId from session
            Booking.CustomerId = Guid.NewGuid();

            Booking.ProductId = productId;

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
