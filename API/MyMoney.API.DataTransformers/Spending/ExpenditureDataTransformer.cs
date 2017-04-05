namespace MyMoney.API.DataTransformers.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataModels.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// The <see cref="ExpenditureDataTransformer"/> class performs transformations on collections of <see cref="ExpenditureDataModel"/>s.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataTransformers.Spending.Interfaces.IExpenditureDataTransformer" />
    [UsedImplicitly]
    public class ExpenditureDataTransformer : IExpenditureDataTransformer
    {
        #region Methods

        /// <summary>
        /// Gets a list of key-value pairs representing the rolling sum of money spent throughout the current month.
        /// </summary>
        /// <param name="expenditure">The expenditure.</param>
        /// <returns>
        /// The list of key-value pairs.
        /// </returns>
        public IList<KeyValuePair<DateTime, double>> GetRollingExpenditureSum(
            IEnumerable<ExpenditureDataModel> expenditure)
        {
            var retVal = new List<KeyValuePair<DateTime, double>>();
            double total = 0;

            foreach (var exp in expenditure.GroupBy(x => x.DateOccurred).OrderBy(x => x.Key))
            {
                total += exp.Sum(x => x.Amount);
                retVal.Add(new KeyValuePair<DateTime, double>(exp.Key, total));
            }

            return retVal.OrderBy(x => x.Value).ToList();
        }

        #endregion
    }
}