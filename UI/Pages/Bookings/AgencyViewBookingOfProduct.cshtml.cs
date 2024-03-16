using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO.Models;
using Service.IService;
using Service;

namespace UI.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public List<Booking> Booking { get;set; } = default!;

        public void OnGet(Guid? productId)
        {
            productId = Guid.Parse("d6f4e6b6-660f-473c-9233-0339335d0a7d");
            Booking = _bookingService.GetBookingsByProductId(productId) ;
        }
    }
}
