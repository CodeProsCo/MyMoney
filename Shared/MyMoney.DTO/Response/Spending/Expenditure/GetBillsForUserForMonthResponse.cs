namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Request.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     The response object for the <see cref="GetExpendituresForUserForMonthRequest" /> class.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetExpendituresForUserForMonthResponse : BaseResponse
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public IList<KeyValuePair<DateTime, double>> Data { get; set; }

        #endregion
    }
}