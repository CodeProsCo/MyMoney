namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using MyMoney.DTO.Request.Spending.Expenditure;
    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    ///     The <see cref="GetExpenditureResponse" /> class is the response object for a <see cref="GetExpenditureRequest" />
    ///     request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetExpenditureResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the expenditure.
        /// </summary>
        /// <value>
        ///     The expenditure.
        /// </value>
        public ExpenditureProxy Expenditure { get; set; }

        #endregion
    }
}