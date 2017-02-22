namespace MyMoney.DTO.Response.Authentication
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    ///     The response object when obtaining user claim information from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetClaimForUserResponse : BaseResponse
    {
        #region  Properties

        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [login success].
        /// </summary>
        /// <value>
        ///     <c>true</c> if login was successful; otherwise, <c>false</c>.
        /// </value>
        public bool LoginSuccess { get; set; }

        public Guid? UserId { get; set; }

        #endregion
    }
}