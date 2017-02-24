namespace MyMoney.DTO.Response.Authentication
{
    #region Usings

    using System;

    using Proxies.Authentication;

    #endregion

    /// <summary>
    ///     The response object when obtaining user claim information from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetClaimForUserResponse : BaseResponse
    {
        #region  Properties

        public UserProxy User { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [login success].
        /// </summary>
        /// <value>
        ///     <c>true</c> if login was successful; otherwise, <c>false</c>.
        /// </value>
        public bool LoginSuccess { get; set; }


        #endregion
    }
}