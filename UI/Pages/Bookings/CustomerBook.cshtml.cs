using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO.Models;
using Service.IService;

namespace UI.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public CreateModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
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
          if (!ModelState.IsValid)
            {
                return Page();
            }
            Booking.Id = Guid.NewGuid();
            Booking.CreatedAt = DateTime.Now;
            Booking.CreatedBy = Guid.NewGuid().ToString();

            // Example: Get userId from session, waiting for session from login
            Booking.CustomerId =Guid.Parse(HttpContext.Session.GetString("Id"));

            Booking.ProductId = productId;

            _bookingService.CreateBooking(Booking);

            //waiting for product detail to return
            return RedirectToPage("/Projects/ProjectsList");
        }
    }
}
