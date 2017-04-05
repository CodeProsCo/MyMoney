namespace MyMoney.API.DataTransformers.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using DataModels.Spending;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillDataTransformer" /> class.
    /// </summary>
    public interface IBillDataTransformer
    {
        #region Methods

        /// <summary>
        ///     Gets the bill category chart data.
        /// </summary>
        /// <param name="bills">The bills.</param>
        /// <returns>A list of key-value pairs for each category and the amount of bills under that category.</returns>
        IList<KeyValuePair<string, int>> GetBillCategoryChartData(IEnumerable<BillDataModel> bills);

        /// <summary>
        ///     Gets the bill period chart data.
        /// </summary>
        /// <param name="bills">The bills.</param>
        /// <returns>A list of key-value pairs for each period and the amount of bills under that period.</returns>
        IList<KeyValuePair<string, int>> GetBillPeriodChartData(IEnumerable<BillDataModel> bills);

        /// <summary>
        ///     Gets the user's outgoing bills for the given month.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="bills">The bills.</param>
        /// <returns>A list of key value pairs of the date and the amount spent on bills on that date.</returns>
        IList<KeyValuePair<DateTime, double>> GetOutgoingBillsForMonth(int monthNumber, IList<BillDataModel> bills);

        #endregion
    }
}