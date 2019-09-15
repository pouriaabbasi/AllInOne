using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AllInOne.Services.Helpers
{
    public static class SecurityHelper
    {
        public static string HashPassword(this string password, string username)
        {
            byte[] salt = Encoding.ASCII.GetBytes(username);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}