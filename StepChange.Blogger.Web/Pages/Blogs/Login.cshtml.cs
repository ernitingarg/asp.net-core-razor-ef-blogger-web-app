using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StepChange.Blogger.DAL;
using StepChange.Blogger.DAL.Services;
using StepChange.Blogger.Web.Security.Services;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {
        readonly IBlogPublisherService _blogPublisherService;
        readonly ITokenService _tokenService;

        public LoginModel(
            IBlogPublisherService blogPublisherService,
            ITokenService tokenService)
        {
            _blogPublisherService = blogPublisherService;
            _tokenService = tokenService;
        }


        [BindProperty]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var publisher = await _blogPublisherService.GetBlogPublisherByPublisherAsync(Name);
            if (publisher == null)
            {
                return NotFound($"No such publisher found with name {Name}.");
            }

            if (publisher.HashPassword != DbUtils.GetHashPassword(Password))
            {
                return BadRequest("Wrong password has been entered.");
            }

            HttpContext.SetJwtToken(_tokenService.GenerateToken(publisher));

            string callbackUrl = HttpContext.GetCallbackUrl();
            if (!string.IsNullOrEmpty(callbackUrl))
            {
                return RedirectToPage(HttpContext.GetCallbackUrl(), new { id = HttpContext.GetCallbackId() });
            }

            return RedirectToPage("./Index");
        }
    }
}
