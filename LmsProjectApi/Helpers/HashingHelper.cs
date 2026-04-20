using System;
using System.Security.Cryptography;

namespace LmsProjectApi.Helpers
{
    public class HashingHelper
    {
        public static string GetHash(string input)
        {
            var salt = new byte[32];
            RandomNumberGenerator.Fill(salt);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password: input,
                salt: salt,
                iterations: 10000,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: 32);

            byte[] hashBytes = new byte[64];

            salt.CopyTo(hashBytes.AsSpan(0, 32));
            hash.CopyTo(hashBytes.AsSpan(32, 32));

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[32];
            Array.Copy(hashBytes, 0, salt, 0, 32);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                password: inputPassword,
                salt: salt,
                iterations: 10000,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: 32);

            byte[] storedPasswordHash = new byte[32];
            Array.Copy(hashBytes, 32, storedPasswordHash, 0, 32);

            return CryptographicOperations.FixedTimeEquals(inputHash, storedPasswordHash);
        }
    }
}
