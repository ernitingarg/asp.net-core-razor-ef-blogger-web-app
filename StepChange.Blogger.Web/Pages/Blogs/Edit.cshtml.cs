using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Services;
using StepChange.Blogger.Web.Attributes;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [RoleAuthorization(Role.Admin, Role.SuperAdmin)]
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        readonly IBlogPostService _blogPostService;

        public EditModel(IBlogPostService blogPostService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // get the latest blog (to be sure its not deleted in between).
            var originalBlog = await _blogPostService.GetBlogPostByIdAsync(id);
            if (originalBlog == null)
            {
                return NotFound("No record found for this post.");
            }

            await TryUpdateModelAsync(
                originalBlog,
                nameof(BlogPost), s => s.Content, s => s.Title);
            originalBlog.ModificationDate = DateTime.Now;

            await _blogPostService.UpdateBlogPostAsync(originalBlog);

            return RedirectToPage("./Index");
        }
    }
}
