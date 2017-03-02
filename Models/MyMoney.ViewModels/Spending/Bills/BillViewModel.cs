namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Enum;

    #endregion

    public class BillViewModel
    {
        #region  Properties

        [UIHint("Currency")]
        [Required]
        public double Amount { get; set; }

        [Required]
        [UIHint("Dropdown")]
        public string Category { get; set; }

        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("Dropdown")]
        public TimePeriod ReoccuringPeriod { get; set; }

        [Required]
        [UIHint("DateTime")]
        public DateTime StartDate { get; set; }

        #endregion
    }
}