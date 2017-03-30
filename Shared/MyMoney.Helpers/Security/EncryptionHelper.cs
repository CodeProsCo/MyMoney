namespace MyMoney.Helpers.Security
{
    #region Usings

    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    #endregion

    /// <summary>
    ///     The <see cref="EncryptionHelper" /> class contains helper functions for performing encryption tasks.
    /// </summary>
    public static class EncryptionHelper
    {
        #region Methods

        /// <summary>
        ///     Creates an instance of the <see cref="EncryptedPasswordModel" /> class based on the given password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>The model.</returns>
        public static EncryptedPasswordModel EncryptPassword(string password)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var passwordBytes = Encoding.ASCII.GetBytes(password);

            var salt = GenerateSalt(passwordBytes.Length);

            var iterations = rnd.Next(100);
            var hash = GenerateHash(passwordBytes, salt, iterations, password.Length);

            return new EncryptedPasswordModel { Salt = salt, Hash = hash, Iterations = iterations };
        }

        /// <summary>
        ///     Validates the given password by creating a new hash for it and comparing it with the given hash.
        /// </summary>
        /// <param name="givenPassword">The given password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="iterations">The iterations.</param>
        /// <returns>If the password is valid, true. Otherwise, false.</returns>
        public static bool ValidatePassword(string givenPassword, byte[] salt, byte[] hash, int iterations)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(givenPassword);
            var newHash = GenerateHash(passwordBytes, salt, iterations, passwordBytes.Length);

            return newHash.SequenceEqual(hash);
        }

        /// <summary>
        ///     Generates a hash using the <see cref="Rfc2898DeriveBytes" /> class.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="length">The length.</param>
        /// <returns>The hash.</returns>
        private static byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return deriveBytes.GetBytes(length);
            }
        }

        /// <summary>
        ///     Generates a salt using the <see cref="RNGCryptoServiceProvider" /> class.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>The salt.</returns>
        private static byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        #endregion
    }
}