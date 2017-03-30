namespace MyMoney.ViewModels.Spending.Expenditure
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MyMoney.Resources;

    #endregion

    /// <summary>
    /// The <see cref="ExpenditureViewModel"/> class contains view information on an expenditure.
    /// </summary>
    public class ExpenditureViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        [UIHint("Currency")]
        [Required]
        [Display(Name = "Label_Amount", ResourceType = typeof(Bills))]
        public double Amount { get; set; }

        /// <summary>
        ///     Gets or sets the category.
        /// </summary>
        /// <value>
        ///     The category.
        /// </value>
        [Required]
        [UIHint("Dropdown")]
        [Display(Name = "Label_Category", ResourceType = typeof(Bills))]
        public string Category { get; set; }

        /// <summary>
        ///     Gets or sets the category identifier.
        /// </summary>
        /// <value>
        ///     The category identifier.
        /// </value>
        [HiddenInput]
        public Guid CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the date occurred.
        /// </summary>
        /// <value>
        ///     The date occurred.
        /// </value>
        [Required]
        [UIHint("DateTime")]
        public DateTime DateOccurred { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [Required]
        [MaxLength(32)]
        [UIHint("String")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [HiddenInput]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        [HiddenInput]
        public Guid UserId { get; set; }

        #endregion
    }
}