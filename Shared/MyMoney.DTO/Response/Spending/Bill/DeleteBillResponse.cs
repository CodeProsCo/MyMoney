namespace MyMoney.DTO.Response.Spending.Bills
{
    #region Usings

    using MyMoney.DTO.Request.Spending.Bill;

    #endregion

    /// <summary>
    ///     The <see cref="DeleteBillResponse" /> class is the response object for a <see cref="DeleteBillRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class DeleteBillResponse : BaseResponse
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