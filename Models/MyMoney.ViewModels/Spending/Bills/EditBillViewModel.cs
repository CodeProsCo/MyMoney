namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The <see cref="EditBillViewModel" /> class contains view information for editing a bill.
    /// </summary>
    public class EditBillViewModel
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the bill.
        /// </summary>
        /// <value>
        ///     The bill.
        /// </value>
        public BillViewModel Bill { get; set; }

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