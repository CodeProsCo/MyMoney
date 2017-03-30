namespace MyMoney.ViewModels.Spending.Expenditure
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The <see cref="TrackExpenditureViewModel"/> class contains view information for tracking expenditure.
    /// </summary>
    public class TrackExpenditureViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the add expenditure.
        /// </summary>
        /// <value>
        /// The add expenditure.
        /// </value>
        public AddExpenditureViewModel AddExpenditure { get; set; }

        /// <summary>
        /// Gets or sets the edit expenditure.
        /// </summary>
        /// <value>
        /// The edit expenditure.
        /// </value>
        public EditExpenditureViewModel EditExpenditure { get; set; }

        /// <summary>
        /// Gets or sets the expenditures.
        /// </summary>
        /// <value>
        /// The expenditures.
        /// </value>
        public IList<ExpenditureViewModel> Expenditures { get; set; }

        #endregion
    }
}