using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var check = _userService.checkLogin(User.Email, User.Password);
            // Check login credentials
            if (check == false)
            {
                // If login fails, set error message
                ErrorMessage = "Invalid email or password.";
                return Page();
            }
            else
            {
                var user = new User();
                user = _userService.GetByEmail(User.Email);

                HttpContext.Session.SetString("Id", user.Id.ToString());

                if (user.RoleId == Guid.Parse("43090161-855a-4d9f-ac61-b4a2432a199e"))
                {
                    return RedirectToPage("./Projects/ProjectsList");
                }
                else if (user.RoleId == Guid.Parse("22FA1BA0-3AAC-4F0E-96ED-BFDFCD780A5E"))
                {
                    return RedirectToPage("./Projects/AgencyViewProjectList");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
