namespace MyMoney.Helpers.Security.Interfaces
{
    /// <summary>
    /// Interface for the <see cref="EncryptionHelper"/> class.
    /// </summary>
    public interface IEncryptionHelper
    {
        #region Methods

        /// <summary>
        /// Encrypts the given password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>The encrypted password model.</returns>
        EncryptedPasswordModel EncryptPassword(string password);

        /// <summary>
        /// Determines if a password is valid, by comparing the stored hash against the hash calculated using the given password.
        /// </summary>
        /// <param name="givenPassword">The given password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="iterations">The iterations.</param>
        /// <returns>True if valid, false if not.</returns>
        bool ValidatePassword(string givenPassword, byte[] salt, byte[] hash, int iterations);

        #endregion
    }
}