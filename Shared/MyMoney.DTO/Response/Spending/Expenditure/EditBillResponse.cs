namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using Request.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     The <see cref="EditExpenditureResponse" /> class is the response object for a <see cref="EditExpenditureRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class EditExpenditureResponse : BaseResponse
    {
        #region  Properties

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