namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    /// The <see cref="GetExpendituresForUserResponse"/> contains all the expenditures for a user.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetExpendituresForUserResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        /// Gets the expenditure count.
        /// </summary>
        /// <value>
        /// The expenditure count.
        /// </value>
        public int ExpenditureCount => Expenditures?.Count ?? 0;

        /// <summary>
        /// Gets or sets the expenditures.
        /// </summary>
        /// <value>
        /// The expenditures.
        /// </value>
        public IList<ExpenditureProxy> Expenditures { get; set; }

        /// <summary>
        /// Gets the expenditure total.
        /// </summary>
        /// <value>
        /// The expenditure total.
        /// </value>
        public double ExpenditureTotal => Expenditures?.Sum(x => x.Amount) ?? 0;

        #endregion
    }
}