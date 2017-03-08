namespace MyMoney.Helpers.Security
{
    #region Usings

    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    #endregion

    public static class EncryptionHelper
    {
        #region  Public Methods

        public static EncryptedPasswordModel EncryptPassword(string password)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var passwordBytes = Encoding.ASCII.GetBytes(password);

            var salt = GenerateSalt(passwordBytes.Length);

            var iterations = rnd.Next(100);
            var hash = GenerateHash(passwordBytes, salt, iterations, password.Length);

            return new EncryptedPasswordModel
            {
                Salt = salt,
                Hash = hash,
                Iterations = iterations
            };
        }

        public static bool ValidatePassword(string givenPassword, byte[] salt, byte[] hash, int iterations)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(givenPassword);
            var newHash = GenerateHash(passwordBytes, salt, iterations, passwordBytes.Length);

            return newHash.SequenceEqual(hash);
        }

        #endregion

        #region Private Methods

        private static byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return deriveBytes.GetBytes(length);
            }
        }

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