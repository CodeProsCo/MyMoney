namespace MyMoney.DTO.Request.Authentication
{
    using Interfaces;

    /// <summary>
    ///     Request used for obtaining user claim information from the database.
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class GetClaimForUserRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetClaimForUserRequest" /> class.
        /// </summary>
        public GetClaimForUserRequest()
            : base("auth/user/get/{0}/{1}/{2}")
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

        #region Implementation of IGetRequest

        public string FormatRequestUri()
        {
            return string.Format(GetAction(), EmailAddress, Password, RequestReference);
        }

        #endregion
    }
}