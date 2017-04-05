namespace MyMoney.ViewModels.Authentication.Account
{
    #region Usings

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Attributes;

    using Resources;

    #endregion

    /// <summary>
    /// The <see cref="AccountDetailsViewModel"/> class contains view information for accounts.
    /// </summary>
    public class AccountDetailsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the confirm new password field.
        /// </summary>
        /// <value>
        /// The confirm new password field.
        /// </value>
        [Display(Name = "Label_ConfirmNewPassword", ResourceType = typeof(Authentication))]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [UIHint("String")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Label_EmailAddress", ResourceType = typeof(Authentication))]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        [UIHint("NewPassword")]
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Label_NewPassword", ResourceType = typeof(Authentication))]
        [ComplexPassword]
        [DisplayName(@"NewPassword")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        [UIHint("Password")]
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Label_OldPassword", ResourceType = typeof(Authentication))]
        public string OldPassword { get; set; }

        #endregion
    }
}