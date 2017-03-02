namespace MyMoney.DTO.Request.Spending
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    public class GetBillRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetBillRequest" /> class.
        /// </summary>
        public GetBillRequest()
            : base("spending/bills/get/{0}/{1}/{2}")
        {
        }

        #endregion

        #region  Properties

        public Guid BillId { get; set; }

        #endregion

        #region Implementation of IGetRequest

        public string FormatRequestUri()
        {
            return string.Format(GetAction(), BillId, RequestReference, Username.Replace("@", ";").Replace(".", ","));
        }

        #endregion
    }
}