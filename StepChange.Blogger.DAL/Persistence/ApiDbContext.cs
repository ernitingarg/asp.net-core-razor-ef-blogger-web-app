using Microsoft.EntityFrameworkCore;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.DAL.Persistence
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<BlogPublisher> BlogPublishers { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BlogPublisher>().HasIndex(x => x.Publisher).IsUnique();

            SeedPublisherRoles(builder);

#if DEBUG
            // Seed, It will generate migration with code-first using add-migrations.
            builder.Initialize();
#endif
        }

        void SeedPublisherRoles(ModelBuilder builder)
        {
            // Seed: Add mandatory Roles
            var adminRole = new PublisherRole
            {
                Id = Role.Admin,
                Description = Role.Admin.GetEnumDescription()
            };
            builder.Entity<PublisherRole>().HasData(adminRole);

            var superAdminRole = new PublisherRole
            {
                Id = Role.SuperAdmin,
                Description = Role.SuperAdmin.GetEnumDescription()
            };
            builder.Entity<PublisherRole>().HasData(superAdminRole);
        }
    }
}