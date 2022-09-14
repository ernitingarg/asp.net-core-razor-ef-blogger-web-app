using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StepChange.Blogger.DAL.Services;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class DetailsModel : PageModel
    {
        readonly IBlogPublisherService _blogPublisherService;

        public DetailsModel(IBlogPublisherService blogPublisherService)
        {
            _blogPublisherService = blogPublisherService;
        }

        public BlogPublisher BlogPublisher { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            BlogPublisher = await _blogPublisherService.GetBlogPublisherByIdAsync(id);
            if (BlogPublisher == null)
            {
                return NotFound("No record found for this publisher.");
            }

            return Page();
        }
    }
}
