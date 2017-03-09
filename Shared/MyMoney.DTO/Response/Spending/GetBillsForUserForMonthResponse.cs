﻿namespace MyMoney.DTO.Response.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Request.Spending;

    #endregion

    /// <summary>
    ///     The response object for the <see cref="GetBillsForUserForMonthRequest" /> class.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillsForUserForMonthResponse : BaseResponse
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