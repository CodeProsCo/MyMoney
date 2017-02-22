namespace MyMoney.DTO.Request.Authentication
{
    /// <summary>
    ///     Request used for obtaining user claim information from the database.
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class GetClaimForUserRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetClaimForUserRequest" /> class.
        /// </summary>
        public GetClaimForUserRequest()
            : base("auth/user/get")
        {
        }

        #endregion

        #region  Properties

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