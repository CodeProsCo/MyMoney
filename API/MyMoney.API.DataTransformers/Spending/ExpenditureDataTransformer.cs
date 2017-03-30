namespace MyMoney.API.DataTransformers.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.Annotations;

    using MyMoney.API.DataTransformers.Spending.Interfaces;
    using MyMoney.DataModels.Spending;

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

            foreach (var exp in expenditure.OrderBy(x => x.DateOccurred))
            {
                var existingDate = retVal.FirstOrDefault(x => x.Key.Equals(exp.DateOccurred));

                if (existingDate.Key == DateTime.MinValue)
                {
                    retVal.Add(new KeyValuePair<DateTime, double>(exp.DateOccurred, exp.Amount));
                }
                else
                {
                    retVal.Remove(existingDate);
                    existingDate = new KeyValuePair<DateTime, double>(existingDate.Key, existingDate.Value + exp.Amount);
                    retVal.Add(existingDate);
                }
            }

            return retVal.OrderBy(x => x.Key).ToList();
        }

        #endregion
    }
}