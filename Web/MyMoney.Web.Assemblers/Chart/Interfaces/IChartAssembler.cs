namespace MyMoney.Web.Assemblers.Chart.Interfaces
{
    #region Usings

    using System;

    using DTO.Request.Chart.Bill;

    #endregion

    /// <summary>
    /// Interface for the <see cref="ChartAssembler"/> class.
    /// </summary>
    public interface IChartAssembler
    {
        #region  Public Methods

        /// <summary>
        /// Creates an instance of the <see cref="GetBillCategoryChartDataRequest"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        GetBillCategoryChartDataRequest NewGetBillCategoryChartDataRequest(Guid userId, string username);

        /// <summary>
        /// Creates an instance of the <see cref="NewGetBillPeriodChartDataRequest"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        GetBillPeriodChartDataRequest NewGetBillPeriodChartDataRequest(Guid userId, string username);

        #endregion
    }
}