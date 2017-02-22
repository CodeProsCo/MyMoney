namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;

    using Enum;

    #endregion

    public class BillViewModel
    {
        #region  Properties

        [UIHint("Currency")]
        [Required]
        public double Amount { get; set; }

        [Required]
        [UIHint("String")]
        public string Category { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("String")]
        public TimePeriod ReoccuringPeriod { get; set; }

        [Required]
        [UIHint("DateTime")]
        public DateTime StartDate { get; set; }

        #endregion
    }
}