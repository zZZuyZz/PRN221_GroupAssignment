using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public void OnGet(string productId)
        {
            Console.WriteLine(productId);
        }
    }
}
