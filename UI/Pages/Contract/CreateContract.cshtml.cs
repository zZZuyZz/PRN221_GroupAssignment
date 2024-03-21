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

        public IActionResult OnGet()
        {

            var loginId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(loginId) || !Guid.TryParse(loginId, out var userId))
            {
                return RedirectToPage("../Index");
            }
           
            ViewData["BookingId"] = new SelectList(_contractService.GetBookingList(), "Id", "CustomerId");

            return Page();
        }

        [BindProperty]
        public BO.Models.Contract Contract { get; set; } = default!;
        public BO.Models.Product Product {  get; set; } = default!;

        public IActionResult OnPostAsync()
        {
            if (Contract == null)
            {
                return Page();
            }

            if (Contract.DepositAmount <0)
            {
                ModelState.AddModelError("Contract.DepositAmount",
                    "Deposit must > 0.");
                return OnGet();
            }

            _contractService.AddContract(Contract);

            return RedirectToPage("./Index");
        }
    }
}

