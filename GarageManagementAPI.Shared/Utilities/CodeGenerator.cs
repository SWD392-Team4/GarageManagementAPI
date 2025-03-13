using System.Security.Cryptography;
using System.Text;

namespace GarageManagementAPI.Shared.Utilities
{
    /// <summary>
    /// Utility class for generating various types of codes
    /// </summary>
    public static class CodeGenerator
    {
        // Exclude confusing characters like 0/O, 1/I/l
        private static readonly char[] allowedChars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();

        /// <summary>
        /// Generates a random alphanumeric code of specified length
        /// </summary>
        /// <param name="length">Length of the code to generate</param>
        /// <returns>A random alphanumeric code</returns>
        public static string GenerateRandomCode(int length = 6)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than zero", nameof(length));

            var result = new StringBuilder(length);
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    // Use modulo to map the random byte to an index within the allowed chars array
                    int index = randomBytes[i] % allowedChars.Length;
                    result.Append(allowedChars[index]);
                }
            }

            return result.ToString();
        }
    }
}
