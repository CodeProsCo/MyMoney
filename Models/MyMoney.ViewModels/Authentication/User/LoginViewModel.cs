namespace MyMoney.ViewModels.Authentication.User
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The <see cref="LoginViewModel" /> contains a user's login information.
    /// </summary>
    public class LoginViewModel
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>
        ///     The email address.
        /// </value>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>
        ///     The password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the return URL.
        /// </summary>
        /// <value>
        ///     The return URL.
        /// </value>
        [HiddenInput]
        public string ReturnUrl { get; set; }

        #endregion
    }
}