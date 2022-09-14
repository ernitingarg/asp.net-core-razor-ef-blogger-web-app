using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Services;

namespace StepChange.Blogger.Web.Pages.Blogs
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        readonly IBlogPostService _blogPostService;

        public IndexModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<BlogPost> BlogPosts { get; set; }

        public async Task OnGetAsync(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (!string.IsNullOrEmpty(searchString))
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var blogs = await _blogPostService.GetAllBlogPostsAsync();
            var filteredBlogs = string.IsNullOrEmpty(searchString)
                ? blogs
                : blogs.Where(s =>
                    s.Title.Contains(searchString)
                    || s.Content.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    filteredBlogs = filteredBlogs.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    filteredBlogs = filteredBlogs.OrderBy(s => s.ModificationDate);
                    break;
                case "date_desc":
                    filteredBlogs = filteredBlogs.OrderByDescending(s => s.ModificationDate);
                    break;
                default:
                    filteredBlogs = filteredBlogs.OrderBy(s => s.Title);
                    break;
            }

            BlogPosts = PaginatedList<BlogPost>.Create(
                filteredBlogs, pageIndex ?? 1, 5);
        }
    }
}
