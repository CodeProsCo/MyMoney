namespace MyMoney.ViewModels.Saving.Goal
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Resources;

    #endregion

    /// <summary>
    /// The <see cref="GoalViewModel"/> class contains view information for goals.
    /// </summary>
    public class GoalViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required]
        [DataType(DataType.Currency)]
        [UIHint("Currency")]
        [Display(Name = "Label_Amount", ResourceType = typeof(Goal))]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoalViewModel"/> is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if complete; otherwise, <c>false</c>.
        /// </value>
        [HiddenInput]
        public bool Complete { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        [DataType(DataType.Date)]
        [UIHint("DateTime")]
        [Display(Name = "Label_EndDate", ResourceType = typeof(Goal))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [HiddenInput]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [UIHint("String")]
        [Display(Name = "Label_Name", ResourceType = typeof(Goal))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [Required]
        [UIHint("DateTime")]
        [Display(Name = "Label_StartDate", ResourceType = typeof(Goal))]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [HiddenInput]
        public Guid UserId { get; set; }

        #endregion
    }
}