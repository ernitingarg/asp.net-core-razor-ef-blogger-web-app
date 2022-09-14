using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Persistence;
using StepChange.Blogger.DAL.Store;

namespace StepChange.Blogger.DAL.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly ILogger<IBlogPostService> _logger;
        private readonly BlogPostStore _blogPostStore;

        public BlogPostService(
            ApiDbContext context,
            ILogger<IBlogPostService> logger)
        {
            _blogPostStore = new BlogPostStore(context);
            _logger = logger;
        }

        public Task<BlogPost> GetBlogPostByIdAsync(Guid id)
        {
            _logger.LogInformation(
                "Fetching Blog Post from DB for ID [{0}]",
                id);

            return _blogPostStore.FindById(id);
        }

        public async Task CreateBlogPostAsync(BlogPost blog)
        {
            _logger.LogInformation(
                "Inserting Blog Post in DB for ID [{0}]",
                blog.Id);

            await _blogPostStore.CreateAsync(blog);
        }

        public async Task UpdateBlogPostAsync(BlogPost blog)
        {
            _logger.LogInformation(
                "Updating Blog Post in DB for ID  [{0}]",
                blog.Id);

            await _blogPostStore.UpdateAsync(blog);
        }

        public Task DeleteBlogPostAsync(BlogPost blog)
        {
            _logger.LogInformation(
                "Deleting Blog Post from DB for ID [{0}]",
                blog.Id);

            return _blogPostStore.DeleteAsync(blog);
        }

        public Task<HashSet<BlogPost>> GetAllBlogPostsAsync()
        {
            _logger.LogInformation(
                "Fetching Blog Posts from DB");

            return _blogPostStore.GetAll();
        }
    }
}
