using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.Web.Security.Services
{
    /// <summary>
    /// Service for managing authentication and authorization
    /// based on secured JWT token.
    /// </summary>
    public class TokenService : ITokenService
    {
        readonly string _signingKey;
        readonly ILogger<ITokenService> _logger;

        public TokenService(
            IConfiguration configuration,
            ILogger<ITokenService> logger)
        {
            _signingKey = configuration.GetJwtSigningKey();
            _logger = logger;
        }

        /// <inheritdoc cref="ITokenService.GenerateToken"/>
        public string GenerateToken(BlogPublisher publisher)
        {
            _logger.LogInformation(
                "Generating Access Token for Publisher ID [{0}]",
                publisher.Id);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, publisher.Id.ToString()),
                new Claim(ClaimTypes.Role, publisher.Role.ToString())
            };

            // Generate token that is valid for 7 days (can be configured same as _signingKey)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = Utils.GenerateSigningCredential(_signingKey)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(jwtToken);
        }

        /// <inheritdoc cref="ITokenService.IsTokenValid"/>
        public bool IsTokenValid(string jwtToken, out Guid? publisherId, out List<Role> roles)
        {
            publisherId = null;
            roles = new List<Role>();

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(
                     jwtToken,
                     Utils.GetDefaultTokenValidationParameters(_signingKey),
                     out SecurityToken validatedToken);

                if (validatedToken == null)
                {
                    return false;
                }

                if (Guid.TryParse(
                        claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                        out Guid value))
                {
                    publisherId = value;
                }

                var claimedRoles = claimsPrincipal.Claims
                    .Where(x => x.Type == ClaimTypes.Role)
                    .Select(x => x.Value).ToList();

                roles.AddRange(claimedRoles.Select(x => Enum.Parse<Role>(x, true)));
            }
            catch (SecurityTokenException)
            {
                return false;
            }

            return true;
        }
    }
}
