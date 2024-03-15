using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO.Models;
using Service.IService;

namespace UI.Pages.Contract
{
    public class CreateModel : PageModel
    {
        private readonly IContractService _contractService;

        public CreateModel(IContractService contractService)
        {
            _contractService = contractService;
        }

        public IActionResult OnGet()
        {
            
            List<Booking> bookings = _contractService.GetBookingList();
            ViewData["AgencyId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contracts == null || Contract == null)
            {
                return Page();
            }

            _context.Contracts.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
