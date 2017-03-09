namespace MyMoney.Helpers.Security
{
    /// <summary>
    ///     The <see cref="EncryptedPasswordModel" /> class contains information on an encrypted password.
    /// </summary>
    public class EncryptedPasswordModel
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the hash.
        /// </summary>
        /// <value>
        ///     The hash.
        /// </value>
        public byte[] Hash { get; set; }

        /// <summary>
        ///     Gets or sets the iterations.
        /// </summary>
        /// <value>
        ///     The iterations.
        /// </value>
        public int Iterations { get; set; }

        /// <summary>
        ///     Gets or sets the salt.
        /// </summary>
        /// <value>
        ///     The salt.
        /// </value>
        public byte[] Salt { get; set; }

        #endregion
    }
}