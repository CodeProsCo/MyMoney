namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using System.Collections.Generic;

    using Proxies.Spending;

    using Request.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     The response object for the <see cref="GetExpenditureForUserForMonthRequest" /> class.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetExpenditureForUserForMonthResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public IEnumerable<ExpenditureProxy> Data { get; set; }

        #endregion
    }
}