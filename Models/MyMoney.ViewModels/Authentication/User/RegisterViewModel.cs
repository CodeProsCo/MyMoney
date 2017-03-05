namespace MyMoney.ViewModels.Authentication.User
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;

    using Attributes;

    #endregion

    /// <summary>
    /// The <see cref="RegisterViewModel"/> class contains view information for registering a user.
    /// </summary>
    public class RegisterViewModel
    {
        #region  Properties

        /// <summary>
        /// Gets or sets a value indicating whether [accept terms and conditions].
        /// </summary>
        /// <value>
        /// <c>true</c> if [accept terms and conditions]; otherwise, <c>false</c>.
        /// </value>
        [RequiredTrue]
        public bool AcceptTermsAndConditions { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [Required]
        [OverEighteenOnly]
        [DataType(DataType.Date)]
        [UIHint("DateTime")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [UIHint("String")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [UIHint("String")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        [ComplexPassword]
        public string Password { get; set; }

        #endregion
    }
}