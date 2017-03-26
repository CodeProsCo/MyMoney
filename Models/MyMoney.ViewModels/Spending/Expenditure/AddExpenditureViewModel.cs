namespace MyMoney.ViewModels.Spending.Expenditure
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The <see cref="AddExpenditureViewModel" /> class contains view information for adding a bill.
    /// </summary>
    public class AddExpenditureViewModel
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the bill.
        /// </summary>
        /// <value>
        ///     The bill.
        /// </value>
        public ExpenditureViewModel Expenditure { get; set; }

        /// <summary>
        ///     Gets or sets the category options.
        /// </summary>
        /// <value>
        ///     The category options.
        /// </value>
        public SelectList CategoryOptions { get; set; }

        /// <summary>
        ///     Gets or sets the time period options.
        /// </summary>
        /// <value>
        ///     The time period options.
        /// </value>
        public SelectList TimePeriodOptions { get; set; }

        #endregion
    }
}