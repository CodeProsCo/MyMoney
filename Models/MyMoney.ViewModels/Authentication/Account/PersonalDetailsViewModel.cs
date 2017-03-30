namespace MyMoney.ViewModels.Authentication.Account
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;

    using MyMoney.Resources;
    using MyMoney.ViewModels.Attributes;

    #endregion

    /// <summary>
    /// The <see cref="PersonalDetailsViewModel"/> class contains view information on personal details.
    /// </summary>
    public class PersonalDetailsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [UIHint("DateTime")]
        [Required]
        [OverEighteenOnly]
        [Display(Name = "Label_DateOfBirth", ResourceType = typeof(Authentication))]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [UIHint("String")]
        [Required]
        [Display(Name = "Label_FirstName", ResourceType = typeof(Authentication))]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [UIHint("String")]
        [Required]
        [Display(Name = "Label_LastName", ResourceType = typeof(Authentication))]
        public string LastName { get; set; }

        #endregion
    }
}