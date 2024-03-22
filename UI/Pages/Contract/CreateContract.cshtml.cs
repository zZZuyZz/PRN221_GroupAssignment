using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Service;
using Service.IService;

namespace UI.Pages.Contract
{
    public class CreateContractModel : PageModel
    {
        private readonly IContractService _contractService;
        private readonly IProductService _productService;
        private readonly IBookingService _bookingService;

        public CreateContractModel(IContractService contractService, IProductService productService, IBookingService bookingService)
        {
            _contractService = contractService;
            _productService = productService;
            _bookingService = bookingService;
        }

        [BindProperty(SupportsGet = true)]
        public BO.Models.Contract Contract { get; set; } = new BO.Models.Contract();
        public Product Product { get; set; } = new Product();
        public Booking Booking { get; set; } = new Booking();

        public IActionResult OnGet(Guid id)
        {
            if (Contract == null)
            {
                Contract = new BO.Models.Contract();
                Product= new Product();
            }

            Contract.Id = Guid.NewGuid();
            var loginId = HttpContext.Session.GetString("Id");
            if (string.IsNullOrEmpty(loginId) || !Guid.TryParse(loginId, out var Id))
            {
                return RedirectToPage("../Index");
            }
            //Product.ProductTitle =_productService.GetById(id).ProductTitle;
            //ViewData["BookingId"] = new SelectList(_bookingService.GetAll(), "CustomerId", "BookingUserName");
            var customers = _bookingService.GetAll();
            var customerList = new SelectList(customers, "CustomerId", "BookingUserName");
            ViewData["CustomerList"] = customerList;

            return Page();
        }


        public IActionResult OnPostAsync()
        {
            if (Contract == null)
            {
                return Page();
            }

            // Validate DepositAmount     
           
            Contract.AgencyId = Guid.Parse(HttpContext.Session.GetString("Id"));
          
            Contract.CreatedAt = DateTime.Now;
            Contract.CreatedBy = HttpContext.Session.GetString("Id");
            _contractService.AddContract(Contract);

            // Redirect to correct page
            return RedirectToPage("/Projects/ProjectsList");
        }
    }

}

