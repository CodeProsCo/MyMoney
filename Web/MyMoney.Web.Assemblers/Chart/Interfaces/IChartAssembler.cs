namespace MyMoney.Web.Assemblers.Chart.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using MyMoney.DTO.Request.Chart.Bill;
    using MyMoney.DTO.Request.Chart.Expenditure;
    using MyMoney.ViewModels.Enum;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ChartAssembler" /> class.
    /// </summary>
    public interface IChartAssembler
    {
        #region Methods

        /// <summary>
        ///     Converts the <see cref="string" /> object in the data list to an instance of the <see cref="TimePeriod" />
        ///     enumeration.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The converted list.</returns>
        IList<KeyValuePair<TimePeriod, int>> AssembleTimePeriodList(IEnumerable<KeyValuePair<string, int>> data);

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillCategoryChartDataRequest" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        GetBillCategoryChartDataRequest NewGetBillCategoryChartDataRequest(Guid userId, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="NewGetBillPeriodChartDataRequest" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        GetBillPeriodChartDataRequest NewGetBillPeriodChartDataRequest(Guid userId, string username);

        /// <summary>
        /// Creates an instance of the <see cref="GetExpenditureChartDataRequest"/> class.
        /// </summary>
        /// <param name="nowMonth">The current month.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>The request object.</returns>
        GetExpenditureChartDataRequest NewGetExpenditureChartDataRequest(int nowMonth, Guid userId, string userEmail);

        #endregion
    }
}