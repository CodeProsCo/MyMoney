namespace MyMoney.API.DataTransformers.Spending.Bills.Interfaces
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
        #region  Public Methods

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