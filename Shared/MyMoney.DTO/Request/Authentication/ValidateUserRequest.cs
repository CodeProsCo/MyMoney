namespace MyMoney.DTO.Request.Authentication
{
    /// <summary>
    ///     Request used for obtaining user claim information from the database.
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class ValidateUserRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidateUserRequest" /> class.
        /// </summary>
        public ValidateUserRequest()
            : base("auth/user/validate/")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>
        ///     The password.
        /// </value>
        public string Password { get; set; }

        #endregion
    }
}