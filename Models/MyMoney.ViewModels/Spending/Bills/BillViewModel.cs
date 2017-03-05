namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Enum;

    #endregion

    public class BillViewModel
    {
        #region  Properties

        [UIHint("Currency")]
        [Required]
        [Display(Name = "Label_Amount", ResourceType = typeof(Resources.Bills))]
        public double Amount { get; set; }

        [Required]
        [UIHint("Dropdown")]
        [Display(Name = "Label_Category", ResourceType = typeof(Resources.Bills))]
        public string Category { get; set; }

        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Label_Name", ResourceType = typeof(Resources.Bills))]
        public string Name { get; set; }

        [Required]
        [UIHint("Dropdown")]
        [Display(Name = "Label_ReoccuringPeriod", ResourceType = typeof(Resources.Bills))]
        public TimePeriod ReoccuringPeriod { get; set; }

        [Required]
        [UIHint("DateTime")]
        [Display(Name = "Label_StartDate", ResourceType = typeof(Resources.Bills))]
        public DateTime StartDate { get; set; }

        [HiddenInput]
        public Guid UserId { get; set; }

        #endregion
    }
}