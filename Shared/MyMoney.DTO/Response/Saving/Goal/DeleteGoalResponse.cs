namespace MyMoney.DTO.Response.Saving.Goal
{
    #region Usings

    using Request.Saving.Goal;

    #endregion

    /// <summary>
    ///     The <see cref="DeleteGoalResponse" /> class is the response object for a <see cref="DeleteGoalRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class DeleteGoalResponse : BaseResponse
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