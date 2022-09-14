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
    /// Provides management of all blog posts.
    /// </summary>
    internal class BlogPostStore : IStore<BlogPost, Guid>
    {
        readonly ApiDbContext _db;

        public BlogPostStore(ApiDbContext db)
        {
            _db = db;
        }

        public Task CreateAsync(BlogPost data)
        {
            _db.Add(data);
            return SaveChangesAsync();
        }

        public Task UpdateAsync(BlogPost data)
        {
            _db.Update(data);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(BlogPost data)
        {
            _db.Remove(data);
            return SaveChangesAsync();
        }

        public Task<BlogPost> FindById(Guid id)
        {
            return Task.FromResult(_db.BlogPosts
                    .Include(u => u.BlogPublisher)
                    .FirstOrDefault(u => u.Id == id));
        }

        public Task<HashSet<Guid>> GetIds()
        {
            return Task.FromResult(_db.BlogPosts.Select(d => d.Id).ToHashSet());
        }

        public Task<HashSet<BlogPost>> GetAll()
        {
            return Task.FromResult(_db.BlogPosts
                .Include(u => u.BlogPublisher)
                .ToHashSet());
        }

        async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
