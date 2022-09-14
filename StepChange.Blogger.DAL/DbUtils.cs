using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StepChange.Blogger.DAL
{
    public static class DbUtils
    {
        /// <summary>
        /// Generate hashed password using crypto sha256 one-way hash algorithm.
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <returns>Cryptographic hashed password</returns>
        public static string GetHashPassword(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA256Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Get enumeration description from an Enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes
                && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
