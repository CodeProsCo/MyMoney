namespace MyMoney.DTO.Request.Spending
{
    using System;

    public class GetBillInformationRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseRequest" /> class.
        /// </summary>
        public GetBillInformationRequest()
            : base("spending/bills/{0}")
        {
        }

        #endregion

        #region  Properties

        public Guid UserId { get; set; }

        #endregion
    }
}