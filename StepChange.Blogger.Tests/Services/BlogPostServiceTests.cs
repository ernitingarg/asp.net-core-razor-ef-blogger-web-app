using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using StepChange.Blogger.DAL;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.DAL.Persistence;
using StepChange.Blogger.DAL.Services;

namespace StepChange.Blogger.Tests.Services
{
    public class BlogPostServiceTests : ManagerTestBase
    {
        [Test]
        public async Task ForAnExistingBlogPost_GetBlogPostById_ShouldReturnRecord()
        {
            await using var context = new ApiDbContext(GetInMemoryDbOptions());

            var service = new BlogPostService(
                context,
                Mock.Of<ILogger<BlogPostService>>());

            var result = await service.GetBlogPostByIdAsync(TestAdminInDb.Id);
            AssertBlogPostParameters(TestAdminInDb, result);
        }

        [Test]
        public async Task ForNonExistingBlogPost_GetBlogPostById_ShouldReturnNull()
        {
            await using var context = new ApiDbContext(GetInMemoryDbOptions());

            var service = new BlogPostService(
                context,
                Mock.Of<ILogger<BlogPostService>>());

            var result = await service.GetBlogPostByIdAsync(Guid.NewGuid());
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateBlogPost_WithValidParameters_ShouldCreateRecord()
        {
            var blogToCreate = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Create_SuperAdmin_Title",
                Content = "Create_SuperAdmin_Content",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                BlogPublisher = new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Create_SuperAdmin_Publisher",
                    HashPassword = DbUtils.GetHashPassword("test"),
                    Role = Role.SuperAdmin
                }
            };

            // Get blog record before insert
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(blogToCreate.Id);
                Assert.IsNull(result);
            }

            // Insert blog record with valid parameters
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                await service.CreateBlogPostAsync(blogToCreate);
            }

            // Get blog record after insert
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(blogToCreate.Id);
                AssertBlogPostParameters(blogToCreate, result);
            }
        }

        [Test]
        public async Task CreateBlogPost_WithInvalidParameters_ShouldNotCreateRecord()
        {
            var invalidBlogToCreate = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Create_SuperAdmin_Title",
                Content = "Create_SuperAdmin_Content",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };

            // Get blog record before insert
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(invalidBlogToCreate.Id);
                Assert.IsNull(result);
            }

            // Insert blog record with invalid parameters
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                await service.CreateBlogPostAsync(invalidBlogToCreate);
            }

            // Get blog record after insert
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(invalidBlogToCreate.Id);
                Assert.IsNull(result);
            }
        }

        [Test]
        public async Task UpdateBlogPost_ShouldUpdateRecord()
        {
            var blogToUpdate = TestAdminInDb;
            blogToUpdate.Title = "New updated title";
            blogToUpdate.Content = "New updated Content";

            // Get blog record before update
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(TestAdminInDb.Id);
                Assert.IsNotNull(result);
                Assert.AreNotEqual(blogToUpdate.Title, result.Title);
                Assert.AreNotEqual(blogToUpdate.Content, result.Content);
            }

            // Update blog record with valid parameters
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                await service.UpdateBlogPostAsync(blogToUpdate);
            }

            // Get blog record after update
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(blogToUpdate.Id);
                AssertBlogPostParameters(blogToUpdate, result);
            }
        }

        [Test]
        public async Task DeleteBlogPost_ShouldDeleteRecord()
        {
            // Get blog record before delete
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(TestSuperAdminInDb.Id);
                Assert.IsNotNull(result);
            }

            // Delete blog record
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                await service.DeleteBlogPostAsync(TestSuperAdminInDb);
            }

            // Get blog record after delete
            await using (var context = new ApiDbContext(GetInMemoryDbOptions()))
            {
                var service = new BlogPostService(
                    context,
                    Mock.Of<ILogger<BlogPostService>>());

                var result = await service.GetBlogPostByIdAsync(TestSuperAdminInDb.Id);
                Assert.IsNull(result);
            }
        }

        void AssertBlogPostParameters(BlogPost expected, BlogPost actual)
        {
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Content, actual.Content);
            Assert.AreEqual(expected.CreationDate, actual.CreationDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.PublisherId, actual.PublisherId);

            Assert.AreEqual(expected.BlogPublisher.Id, actual.BlogPublisher.Id);
            Assert.AreEqual(expected.BlogPublisher.Publisher, actual.BlogPublisher.Publisher);
            Assert.AreEqual(expected.BlogPublisher.Role, actual.BlogPublisher.Role);
            Assert.AreEqual(expected.BlogPublisher.HashPassword, actual.BlogPublisher.HashPassword);
        }
    }
}
