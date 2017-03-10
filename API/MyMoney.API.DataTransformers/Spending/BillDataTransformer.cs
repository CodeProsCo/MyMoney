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
    ///     The <see cref="BillDataTransformer" /> class converts raw bill data models into other data formats.
    /// </summary>
    /// <seealso cref="IBillDataTransformer" />
    [UsedImplicitly]
    public class BillDataTransformer : IBillDataTransformer
    {
        #region  Public Methods

        /// <summary>
        /// Gets the bill category chart data.
        /// </summary>
        /// <param name="bills">The bills.</param>
        /// <returns>
        /// A list of key-value pairs for each category and the amount of bills under that category.
        /// </returns>
        public IList<KeyValuePair<string, int>> GetBillCategoryChartData(IEnumerable<BillDataModel> bills)
        {
            var grouping = bills.GroupBy(x => x.Category.Name);

            return grouping.Select(group => new KeyValuePair<string, int>(group.Key.ToString(), group.Count())).ToList();
        }

        /// <summary>
        /// Gets the bill period chart data.
        /// </summary>
        /// <param name="bills">The bills.</param>
        /// <returns>
        /// A list of key-value pairs for each period and the amount of bills under that period.
        /// </returns>
        public IList<KeyValuePair<string, int>> GetBillPeriodChartData(IEnumerable<BillDataModel> bills)
        {
            var grouping = bills.GroupBy(x => x.ReoccurringPeriod);

            return grouping.Select(group => new KeyValuePair<string, int>(group.Key.ToString(), group.Count())).ToList();
        }

        /// <summary>
        ///     Gets the user's outgoing bills for the given month.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="bills">The bills.</param>
        /// <returns>
        ///     A list of key value pairs of the date and the amount spent on bills on that date.
        /// </returns>
        public IList<KeyValuePair<DateTime, double>> GetOutgoingBillsForMonth(
            int monthNumber, 
            IList<BillDataModel> bills)
        {
            // var weeklyBills = bills.Where(x => x.ReoccurringPeriod == 1).ToList();
            var dailyBills = bills.Where(x => x.ReoccurringPeriod == 0).ToList();
            var monthlyBills = bills.Where(x => x.ReoccurringPeriod == 2).ToList();
            var yearlyBills = bills.Where(x => x.ReoccurringPeriod == 3).ToList();
            var retVal = new List<KeyValuePair<DateTime, double>>();

            for (var date = new DateTime(DateTime.Now.Year, monthNumber, 1);
                 date < new DateTime(DateTime.Now.Year, monthNumber + 1, 1);
                 date = date.AddDays(1))
            {
                double amount = 0;
                var currentDate = date;

                if (dailyBills.Any())
                {
                    amount += dailyBills.Sum(bill => bill.Amount);
                }

                if (monthlyBills.Any(x => x.StartDate.Day == date.Day))
                {
                    var todaysBills = monthlyBills.Where(x => x.StartDate.Day == currentDate.Day);

                    amount += todaysBills.Sum(bill => bill.Amount);
                }

                if (yearlyBills.Any(x => x.StartDate.Day == date.Day && x.StartDate.Month == monthNumber))
                {
                    var todaysBills =
                        yearlyBills.Where(x => x.StartDate.Day == currentDate.Day && x.StartDate.Month == monthNumber);

                    amount += todaysBills.Sum(bill => bill.Amount);
                }

                if (amount > 0)
                {
                    retVal.Add(new KeyValuePair<DateTime, double>(date, amount));
                }
            }

            return retVal;
        }

        #endregion
    }
}