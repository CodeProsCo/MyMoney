namespace MyMoney.API.DataTransformers.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using MyMoney.DataModels.Spending;

    #endregion

    /// <summary>
    /// Interface for the <see cref="ExpenditureDataTransformer"/> class.
    /// </summary>
    public interface IExpenditureDataTransformer
    {
        #region Methods

        /// <summary>
        /// Gets a list of key-value pairs representing the rolling sum of money spent throughout the current month.
        /// </summary>
        /// <param name="expenditure">The expenditure.</param>
        /// <returns>The list of key-value pairs.</returns>
        IList<KeyValuePair<DateTime, double>> GetRollingExpenditureSum(IEnumerable<ExpenditureDataModel> expenditure);

        #endregion
    }
}