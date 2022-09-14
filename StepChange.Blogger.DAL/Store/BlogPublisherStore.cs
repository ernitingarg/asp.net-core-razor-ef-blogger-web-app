using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Persistence;

namespace StepChange.Blogger.DAL.Store
{
    /// <summary>
    /// Provides management of all blog publishers.
    /// </summary>
    internal class BlogPublisherStore : IStore<BlogPublisher, Guid>
    {
        readonly ApiDbContext _db;

        public BlogPublisherStore(ApiDbContext db)
        {
            _db = db;
        }

        public Task CreateAsync(BlogPublisher data)
        {
            _db.Add(data);
            return SaveChangesAsync();
        }

        public Task UpdateAsync(BlogPublisher data)
        {
            _db.Update(data);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(BlogPublisher data)
        {
            _db.Remove(data);
            return SaveChangesAsync();
        }

        public Task<BlogPublisher> FindById(Guid id)
        {
            return Task.FromResult(_db.BlogPublishers
                .Include(u => u.BlogPosts)
                .FirstOrDefault(u => u.Id == id));
        }

        public Task<HashSet<Guid>> GetIds()
        {
            return Task.FromResult(_db.BlogPublishers.Select(d => d.Id).ToHashSet());
        }

        public Task<HashSet<BlogPublisher>> GetAll()
        {
            return Task.FromResult(_db.BlogPublishers
                .Include(u => u.BlogPosts)
                .ToHashSet());
        }

        public Task<BlogPublisher> FindByPublisher(string publisher)
        {
            return Task.FromResult(_db.BlogPublishers
                .Include(u => u.BlogPosts)
                .FirstOrDefault(u => u.Publisher.ToLower() == publisher.ToLower()));
        }

        async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
