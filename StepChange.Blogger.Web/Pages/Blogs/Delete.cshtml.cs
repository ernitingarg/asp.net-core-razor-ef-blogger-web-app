using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Services;
using StepChange.Blogger.Web.Attributes;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [RoleAuthorization(Role.SuperAdmin)]
    [IgnoreAntiforgeryToken]
    public class DeleteModel : PageModel
    {
        readonly IBlogPostService _blogPostService;

        public DeleteModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            BlogPost = await _blogPostService.GetBlogPostByIdAsync(id);
            if (BlogPost == null)
            {
                return NotFound("No record found for this post.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            await _blogPostService.DeleteBlogPostAsync(BlogPost);

            return RedirectToPage("./Index");
        }
    }
}
