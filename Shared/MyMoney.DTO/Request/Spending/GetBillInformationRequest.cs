namespace MyMoney.DTO.Request.Spending
{
    #region Usings

    using System;

    using Interfaces;

    #endregion

    public class GetBillInformationRequest : BaseRequest, IGetRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetBillInformationRequest" /> class.
        /// </summary>
        public GetBillInformationRequest()
            : base("spending/bills/user/{0}/{1}/{2}")
        {
        }

        #endregion

        #region  Properties

        public Guid UserId { get; set; }

        #endregion

        #region Implementation of IGetRequest

        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, RequestReference, Username.Replace("@", ";").Replace(".", ","));
        }

        #endregion
    }
}