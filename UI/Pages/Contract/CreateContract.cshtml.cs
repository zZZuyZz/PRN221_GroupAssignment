using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using Service.IService;

namespace UI.Pages.Contract
{
    public class CreateContractModel : PageModel
    {
        private readonly IContractService _contractService;
        private readonly IProductService _productService;
        public CreateContractModel(IContractService contractService,IProductService productService)
        {
            _contractService = contractService;
            _productService = productService;
        }
        [BindProperty(SupportsGet = true)]
        public Guid ProductId { get; set; }

        public string ProductTitle { get; set; }
        public IActionResult OnGet()
        {

            var loginId = HttpContext.Session.GetString("Id");
            if (string.IsNullOrEmpty(loginId) || !Guid.TryParse(loginId, out var Id))
            {
               return RedirectToPage("../Index");
            }

            var product = _productService.GetById(ProductId);
            if (product != null)
            {
                // Assign product title to display in the form
                ProductTitle = product.ProductTitle;
            }
            ViewData["BookingId"] = new SelectList(_contractService.GetBookingList(), "AgencyId", "AgencyId");
            return Page();
        }

        [BindProperty]
        public BO.Models.Contract Contract { get; set; } = default!;
        public Product Product {  get; set; } = default!;

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

            return RedirectToPage("/Booking/Details");
        }
    }
}

