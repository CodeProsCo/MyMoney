namespace MyMoney.Web.Assemblers.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DTO.Request.Chart.Bill;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Spending.Bills.Enum;

    #endregion

    /// <summary>
    ///     The <see cref="ChartAssembler" /> class creates request objects and extracts data from response objects regarding
    ///     charts.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Chart.Interfaces.IChartAssembler" />
    [UsedImplicitly]
    public class ChartAssembler : IChartAssembler
    {
        #region  Public Methods

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
            return new GetBillPeriodChartDataRequest { UserId = userId, Username = username };
        }

        #endregion
    }
}