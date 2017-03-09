namespace MyMoney.DTO.Response.Authentication
{
    #region Usings

    using Request.Authentication;

    #endregion

    /// <summary>
    ///     The <see cref="RegisterUserResponse" /> class is the response object for a <see cref="RegisterUserRequest" />
    ///     request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class RegisterUserResponse : BaseResponse
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets a value indicating whether [register success].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [register success]; otherwise, <c>false</c>.
        /// </value>
        public bool RegisterSuccess { get; set; }

        #endregion
    }
}