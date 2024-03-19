    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.IService;

namespace UI.Pages.Contract
{
    public class CreateContractModel : PageModel
    {
        private readonly IContractService _contractService;

        public CreateContractModel(IContractService contractService)
        {
            _contractService = contractService;
        }

        public IActionResult OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }
            var correspondingauthor = _contractService.GetContract(id);
            if (correspondingauthor == null)
            {
                return RedirectToPage("./Index");
            }

            Contract = correspondingauthor;
            ViewData["BookingId"] = new SelectList(_contractService.GetBookingList(), "Id", "CustomerId");
            ViewData["BookingId"] = new SelectList(_contractService.GetBookingList(), "Id", "AgencyId");
            ViewData["ProductId"] = new SelectList(_contractService.GetBookingList(), "Id", "CustomerId");

            return Page();
        }

        [BindProperty]
        public BO.Models.Contract Contract { get; set; } = default!;


    }
}
}
