using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StepChange.Blogger.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Blogs/Index");
        }
    }
}
