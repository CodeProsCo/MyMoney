namespace MyMoney.Web.Assemblers.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.Annotations;

    using MyMoney.DTO.Request.Chart.Bill;
    using MyMoney.DTO.Request.Chart.Expenditure;
    using MyMoney.ViewModels.Enum;
    using MyMoney.Web.Assemblers.Chart.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="ChartAssembler" /> class creates request objects and extracts data from response objects regarding
    ///     charts.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Chart.Interfaces.IChartAssembler" />
    [UsedImplicitly]
    public class ChartAssembler : IChartAssembler
    {
        #region Methods

        /// <summary>
        ///     Converts the <see cref="string" /> object in the data list to an instance of the <see cref="TimePeriod" />
        ///     enumeration.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>
        ///     The converted list.
        /// </returns>
        public IList<KeyValuePair<TimePeriod, int>> AssembleTimePeriodList(IEnumerable<KeyValuePair<string, int>> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return (from item in data
                    let enumeration = (TimePeriod)int.Parse(item.Key)
                    select new KeyValuePair<TimePeriod, int>(enumeration, item.Value)).ToList();
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillCategoryChartDataRequest" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetBillCategoryChartDataRequest NewGetBillCategoryChartDataRequest(Guid userId, string username)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetBillCategoryChartDataRequest { UserId = userId, Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="NewGetBillPeriodChartDataRequest" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetBillPeriodChartDataRequest NewGetBillPeriodChartDataRequest(Guid userId, string username)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetBillPeriodChartDataRequest { UserId = userId, Username = username };
        }

        /// <summary>
        /// Creates an instance of the <see cref="GetExpenditureChartDataRequest" /> class.
        /// </summary>
        /// <param name="nowMonth">The current month.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Exception thrown if the given month is out of range.</exception>
        public GetExpenditureChartDataRequest NewGetExpenditureChartDataRequest(
            int nowMonth,
            Guid userId,
            string userEmail)
        {
            if (nowMonth < 1 || nowMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(nowMonth));
            }

            return new GetExpenditureChartDataRequest { UserId = userId, Username = userEmail, Month = nowMonth };
        }

        #endregion
    }
}