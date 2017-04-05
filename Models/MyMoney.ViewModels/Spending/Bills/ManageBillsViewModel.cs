namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using Enum;

    #endregion

    /// <summary>
    /// The <see cref="ManageBillsViewModel"/> class contains view information for managing bills.
    /// </summary>
    public class ManageBillsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the add model.
        /// </summary>
        /// <value>
        /// The add model.
        /// </value>
        public AddBillViewModel AddModel { get; set; }

        /// <summary>
        /// Gets the bill categories.
        /// </summary>
        /// <value>
        /// The bill categories.
        /// </value>
        public IEnumerable<IGrouping<string, BillViewModel>> BillCategories => Bills.GroupBy(x => x.Category);

        /// <summary>
        /// Gets the bill count.
        /// </summary>
        /// <value>
        /// The bill count.
        /// </value>
        public int BillCount => Bills?.Count ?? 0;

        /// <summary>
        /// Gets the bill periods.
        /// </summary>
        /// <value>
        /// The bill periods.
        /// </value>
        public IEnumerable<IGrouping<TimePeriod, BillViewModel>> BillPeriods => Bills.GroupBy(x => x.ReoccurringPeriod);

        /// <summary>
        /// Gets or sets the bills.
        /// </summary>
        /// <value>
        /// The bills.
        /// </value>
        public IList<BillViewModel> Bills { get; set; }

        /// <summary>
        /// Gets or sets the edit model.
        /// </summary>
        /// <value>
        /// The edit model.
        /// </value>
        public EditBillViewModel EditModel { get; set; }

        #endregion
    }
}