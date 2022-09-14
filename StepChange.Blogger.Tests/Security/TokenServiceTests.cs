using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using StepChange.Blogger.DAL;
using StepChange.Blogger.DAL.Models;
using StepChange.Blogger.Web.Security.Services;

namespace StepChange.Blogger.Tests.Security
{
    public class TokenServiceTests
    {
        readonly string _securityKey = "fNwEZFVhHiwqzocPNTLSZqryJxsyFyRp";
        ITokenService _tokenService;

        [SetUp]
        public void Setup()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string>
            {
                { "Jwt:SigningKey", _securityKey },
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _tokenService =
                new TokenService(configuration, Mock.Of<ILogger<TokenService>>());
        }

        [Test]
        public void ForAGivenBlobPublisher_IssueJwtToken_ValidateValidSignedTokenHasBeenIssued()
        {
            var blogPublisher = new BlogPublisher
            {
                Id = Guid.NewGuid(),
                Publisher = "TestPublisher",
                HashPassword = DbUtils.GetHashPassword("Test123"),
                Role = Role.Admin
            };

            // Generate JWT token
            string jwtToken = _tokenService.GenerateToken(blogPublisher);

            // Validate generated JWT token
            bool isValidToken = _tokenService.IsTokenValid(
                jwtToken,
                out Guid? publisherId,
                out List<Role> roles);

            Assert.IsTrue(isValidToken);
            Assert.AreEqual(blogPublisher.Id, publisherId);
            Assert.IsTrue(roles.Count == 1);
            Assert.AreEqual(blogPublisher.Role, roles.First());
        }
    }
}
