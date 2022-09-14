using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StepChange.Blogger.DAL;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Persistence;

namespace StepChange.Blogger.Tests
{
    public class ManagerTestBase
    {
        const string InitialDbName = "Initial_Db_Tests";

        protected static BlogPost TestAdminInDb { get; } = new BlogPost
        {
            Id = Guid.NewGuid(),
            Title = "Admin_Title",
            Content = "Admin_Content",
            CreationDate = DateTime.Now,
            ModificationDate = DateTime.Now,
            BlogPublisher = new BlogPublisher
            {
                Id = Guid.NewGuid(),
                Publisher = "Admin_Publisher",
                HashPassword = DbUtils.GetHashPassword("test"),
                Role = Role.Admin
            }
        };

        protected static BlogPost TestSuperAdminInDb { get; } = new BlogPost
        {
            Id = Guid.NewGuid(),
            Title = "SuperAdmin_Title",
            Content = "SuperAdmin_Content",
            CreationDate = DateTime.Now,
            ModificationDate = DateTime.Now,
            BlogPublisher = new BlogPublisher
            {
                Id = Guid.NewGuid(),
                Publisher = "SuperAdmin_Publisher",
                HashPassword = DbUtils.GetHashPassword("test"),
                Role = Role.SuperAdmin
            }
        };

        [SetUp]
        public void Setup()
        {
            // setup defaultDb for each test
            using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                // empty db
                context.Database.EnsureDeletedAsync();

                // new db
                context.Database.EnsureCreatedAsync();

                context.SaveChangesAsync();
            }

            // Add test publishers
            using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                context.AddAsync(TestAdminInDb);
                context.AddAsync(TestSuperAdminInDb);

                context.SaveChangesAsync();
            }
        }

        protected DbContextOptions<ApiDbContext> GetInMemoryDbOptions(string dbName = InitialDbName)
        {
            return new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .EnableSensitiveDataLogging()
                .Options;
        }
    }
}
