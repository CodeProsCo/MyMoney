namespace MyMoney.DTO.Request.Authentication
{
    #region Usings

    using System;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="RegisterUserRequest" /> class is used to register a user.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class RegisterUserRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterUserRequest" /> class.
        /// </summary>
        public RegisterUserRequest()
            : base("auth/user/register")
        {
        }

        #endregion

        #region  Properties

        /// <summary>
        ///     Gets or sets the date of birth.
        /// </summary>
        /// <value>
        ///     The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>
        ///     The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; [UsedImplicitly] set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; [UsedImplicitly] set; }

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