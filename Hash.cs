using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace GDBank
{
    class Hash
    {
        /// <summary>
        /// Takes the given password and hashes it with a static salt using the PBKDF2 algorithm
        /// </summary>
        /// <param name="password"></param>
        /// <returns>The hashed and salted version of the password</returns>
        public static string HashPassword(string password)
        {
            // convert the salt into a byte array
            string saltStr = "change_me"; // demo salt for developement, this will be changed once hosted
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
