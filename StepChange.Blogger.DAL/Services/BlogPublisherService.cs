using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Persistence;
using StepChange.Blogger.DAL.Store;

namespace StepChange.Blogger.DAL.Services
{
    public class BlogPublisherService : IBlogPublisherService
    {
        private readonly ILogger<IBlogPublisherService> _logger;
        private readonly BlogPublisherStore _blogPublisherStore;

        public BlogPublisherService(
            ApiDbContext context,
            ILogger<IBlogPublisherService> logger)
        {
            _blogPublisherStore = new BlogPublisherStore(context);
            _logger = logger;
        }

        public Task<BlogPublisher> GetBlogPublisherByIdAsync(Guid id)
        {
            _logger.LogInformation(
                "Fetching Blog Publisher from DB for ID [{0}]",
                id);

            return _blogPublisherStore.FindById(id);
        }

        public Task<BlogPublisher> GetBlogPublisherByPublisherAsync(string publisher)
        {
            _logger.LogInformation(
                "Fetching Blog Publisher from DB for Publisher [{0}]",
                publisher);

            return _blogPublisherStore.FindByPublisher(publisher);
        }

        public Task<HashSet<BlogPublisher>> GetAllBlogPublishersAsync()
        {
            _logger.LogInformation(
                "Fetching Blog Publishers from DB");

            return _blogPublisherStore.GetAll();
        }
    }
}
