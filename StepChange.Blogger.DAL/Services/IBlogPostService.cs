using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.DAL.Services
{
    /// <summary>
    /// Service for CRUD operation on blog post
    /// </summary>
    public interface IBlogPostService
    {
        Task<BlogPost> GetBlogPostByIdAsync(Guid id);
        Task CreateBlogPostAsync(BlogPost blog);
        Task UpdateBlogPostAsync(BlogPost blog);
        Task DeleteBlogPostAsync(BlogPost blog);
        Task<HashSet<BlogPost>> GetAllBlogPostsAsync();
    }
}
