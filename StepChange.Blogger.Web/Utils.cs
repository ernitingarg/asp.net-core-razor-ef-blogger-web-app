using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace StepChange.Blogger.Web
{
    public static class Utils
    {
        /// <summary>
        /// Returns JWT signing raw key from appsettings configuration
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public static string GetJwtSigningKey(this IConfiguration configuration)
        {
            string signingKey = configuration["Jwt:SigningKey"];

            if (string.IsNullOrEmpty(signingKey))
            {
                throw new ArgumentNullException(
                    nameof(IConfiguration),
                    "Missing 'Jwt:SigningKey' in appsettings.json");
            }

            return signingKey;
        }

        /// <summary>
        /// Generate Symmetric security key from a given signing key.
        /// </summary>
        /// <param name="signingKey">Given signing key as string</param>
        /// <returns><see cref="SymmetricSecurityKey"/></returns>
        public static SymmetricSecurityKey GenerateSecurityKey(string signingKey)
        {
            var keyBytes = Convert.FromBase64String(signingKey);

            return new SymmetricSecurityKey(keyBytes);
        }

        /// <summary>
        /// Generate signed credential (algorithm and digest)
        /// from given signing key to be used for digital signatures.
        /// </summary>
        /// <param name="signingKey">Given signing key as string</param>
        /// <returns><see cref="SigningCredentials"/></returns>
        public static SigningCredentials GenerateSigningCredential(string signingKey)
        {
            return new SigningCredentials(
                GenerateSecurityKey(signingKey),
                SecurityAlgorithms.HmacSha256Signature);
        }

        public static TokenValidationParameters GetDefaultTokenValidationParameters(
            string signingKey)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GenerateSecurityKey(signingKey),
                ClockSkew = TimeSpan.Zero // tokens expire exactly at token expiration time.
            };
        }

        public static void SetSessionValue(this HttpContext context, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                context.Session.SetString(key, value);
            }
        }

        public static string GetSessionValue(this HttpContext context, string key)
        {
            return context.Session.GetString(key);
        }

        public static void SetJwtToken(this HttpContext context, string value)
        {
            context.SetSessionValue("JwtToken", value);
        }

        public static string GetJwtToken(this HttpContext context)
        {
            return context.GetSessionValue("JwtToken");
        }

        public static void SetCallbackUrl(this HttpContext context, string value)
        {
            context.SetSessionValue("RequestedUrl", value);
        }

        public static string GetCallbackUrl(this HttpContext context)
        {
            return context.GetSessionValue("RequestedUrl");
        }

        public static void SetCallbackId(this HttpContext context, string value)
        {
            context.SetSessionValue("RequestedId", value);
        }

        public static string GetCallbackId(this HttpContext context)
        {
            return context.GetSessionValue("RequestedId");
        }
    }
}
