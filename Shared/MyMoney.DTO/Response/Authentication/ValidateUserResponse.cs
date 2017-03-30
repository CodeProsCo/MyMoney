namespace MyMoney.DTO.Response.Authentication
{
    #region Usings

    using MyMoney.Proxies.Authentication;

    #endregion

    /// <summary>
    ///     The response object when obtaining user claim information from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class ValidateUserResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether [login success].
        /// </summary>
        /// <value>
        ///     <c>true</c> if login was successful; otherwise, <c>false</c>.
        /// </value>
        public bool LoginSuccess { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        /// <value>
        ///     The user.
        /// </value>
        public UserProxy User { get; set; }

        #endregion
    }
}