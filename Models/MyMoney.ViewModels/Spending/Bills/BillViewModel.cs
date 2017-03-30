namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MyMoney.Resources;
    using MyMoney.ViewModels.Enum;

    #endregion

    /// <summary>
    ///     The <see cref="BillViewModel" /> class contains view information on a bill.
    /// </summary>
    public class BillViewModel
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
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [HiddenInput]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [Required]
        [Display(Name = "Label_Name", ResourceType = typeof(Bills))]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the reoccurring period.
        /// </summary>
        /// <value>
        ///     The reoccurring period.
        /// </value>
        [Required]
        [UIHint("Dropdown")]
        [Display(Name = "Label_ReoccuringPeriod", ResourceType = typeof(Bills))]
        public TimePeriod ReoccurringPeriod { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>
        ///     The start date.
        /// </value>
        [Required]
        [UIHint("DateTime")]
        [Display(Name = "Label_StartDate", ResourceType = typeof(Bills))]
        public DateTime StartDate { get; set; }

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