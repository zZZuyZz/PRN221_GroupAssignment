using BO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;

namespace UI.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public User User { get; set; } = default;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var exist = _userService.GetByEmail(User.Email);
            if (exist == null)
            {
                User.Id = Guid.NewGuid();
                _userService.Regiter(User);
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Email already exists.";
                return Page();
            }

        }
    }
}
