using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Services;
using StepChange.Blogger.Web.Attributes;
using StepChange.Blogger.Web.Security.Services;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [RoleAuthorization(Role.Admin, Role.SuperAdmin)]
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        readonly IBlogPublisherService _blogPublisherService;
        readonly IBlogPostService _blogPostService;
        readonly ITokenService _tokenService;

        public CreateModel(
            IBlogPublisherService blogPublisherService,
            IBlogPostService blogPostService,
            ITokenService tokenService)
        {
            _blogPublisherService = blogPublisherService;
            _blogPostService = blogPostService;
            _tokenService = tokenService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public BlogPost BlogPost { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Auto assign the publisher from currently used session.
            if (!_tokenService.IsTokenValid(HttpContext.GetJwtToken(), out var publisherId, out _)
                || !publisherId.HasValue)
            {
                // corner case redirect to login
                return RedirectToPage("./Login");
            }

            var blogPublisher = await _blogPublisherService.GetBlogPublisherByIdAsync(publisherId.Value);
            if (blogPublisher == null)
            {
                return NotFound("No record found for currently logged-in user. " +
                                "Refresh the page to in-case account is deleted.");
            }

            BlogPost.BlogPublisher = blogPublisher;

            await _blogPostService.CreateBlogPostAsync(BlogPost);

            return RedirectToPage("./Index");
        }
    }
}