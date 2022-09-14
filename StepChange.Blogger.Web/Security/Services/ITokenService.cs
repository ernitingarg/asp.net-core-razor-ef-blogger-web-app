using System;
using System.Collections.Generic;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.Web.Security.Services
{
    /// <summary>
    /// Abstracts the access token provider
    /// with the Signing Credentials (SecurityKey and signing algorithm).
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate and sign a JWT access token with expiration time.
        /// This token contains the publisher id and the role of the publisher.
        /// </summary>
        /// <param name="publisher">Publisher to grant the access token.</param>
        /// <returns>Signed JWT access token containing the user id and the role.</returns>
        string GenerateToken(BlogPublisher publisher);

        /// <summary>
        /// Validate if given JWT token is valid token.
        /// </summary>
        /// <param name="jwtToken">JWT token to validate.</param>
        /// <param name="publisherId">Returns publisher id from JWT token</param>
        /// <param name="roles">Returns publisher all roles from JWT token</param>
        /// <returns>true if given JWT token is a valid token.</returns>
        bool IsTokenValid(string jwtToken, out Guid? publisherId, out List<Role> roles);
    }
}
