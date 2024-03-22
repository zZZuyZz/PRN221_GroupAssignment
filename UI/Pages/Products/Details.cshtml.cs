using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration.UserSecrets;
using Service.IService;
using System;

namespace UI.Pages.Products
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public bool IsRegistered { get; set; } = true;
        [BindProperty]
        public int BookedCount { get; set; }

        private readonly IProductService _productService;
        private readonly IBookingService _bookingService;

        public DetailsModel(IProductService productService, IBookingService bookingService)
        {
            _productService = productService;
            _bookingService = bookingService;
        }

        public IActionResult OnGet(string productId)
        {
            try
            {
                Guid guid = Guid.Parse(productId);
                var product = _productService.GetProductById(guid, true);
                
                if (product == null)
                {
                    return RedirectToPage("/Error");
                }
                Product = product;

                //var userId = HttpContext.Session.GetString("Id");

                List<Booking> bookings = _bookingService.GetBookingsByProductId(guid) ?? new();
                var book = bookings?.FirstOrDefault(x => x.CustomerId.Equals(Guid.Parse("314F3DE7-ED73-4B08-AAD6-C2CCBECD32C2"))) ?? null;
                IsRegistered = book != null;
                BookedCount = bookings.Count;
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
                throw;
            }

        }

        public IActionResult OnPostBooking(Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return RedirectToPage("/Error");
            }

            //string? uid = HttpContext.Session.GetString("Id");
            string uid = "314F3DE7-ED73-4B08-AAD6-C2CCBECD32C2";
            if (uid == null)
            {
                return RedirectToPage("/Error");
            }

            var newBooking = new Booking()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse(uid),
                ProductId = product.Id,
                CreatedAt = DateTime.Now
            };

            var isSuccess = _bookingService.CreateBooking(newBooking);
            if (isSuccess)
            {

                ViewData["bookingMessage"] = "Booked successfully";
                return RedirectToPage($"/Products/Details", id.ToString());
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
