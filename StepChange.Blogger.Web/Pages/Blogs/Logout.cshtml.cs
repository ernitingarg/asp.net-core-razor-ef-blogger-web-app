using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            string jwtToken = HttpContext.GetJwtToken();
            if (string.IsNullOrEmpty(jwtToken))
            {
                return RedirectToPage("./Index");
            }

            HttpContext.Session.Clear();

            return RedirectToPage("./Login");
        }
    }
}
