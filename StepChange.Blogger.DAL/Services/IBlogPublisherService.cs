using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.DAL.Services
{
    /// <summary>
    /// Service for CRUD operation on blog publishers
    /// Currently, it supports only GET apis but can be
    /// extended for publisher/user management.
    /// </summary>
    public interface IBlogPublisherService
    {
        Task<BlogPublisher> GetBlogPublisherByIdAsync(Guid id);
        Task<BlogPublisher> GetBlogPublisherByPublisherAsync(string publisher);
        Task<HashSet<BlogPublisher>> GetAllBlogPublishersAsync();
    }
}