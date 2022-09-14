using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StepChange.Blogger.Web.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ForbiddenModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
