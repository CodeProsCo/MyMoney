namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using Request.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     The <see cref="DeleteExpenditureResponse" /> class is the response object for a
    ///     <see cref="DeleteExpenditureRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class DeleteExpenditureResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether [delete success].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [delete success]; otherwise, <c>false</c>.
        /// </value>
        public bool DeleteSuccess { get; set; }

        #endregion
    }
}