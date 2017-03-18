namespace MyMoney.DTO.Response.Spending.Expenditure
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using Proxies.Spending;

    #endregion

    public class GetExpendituresForUserResponse : BaseResponse
    {
        #region  Properties

        public int ExpenditureCount => Expenditures?.Count ?? 0;

        public IList<ExpenditureProxy> Expenditures { get; set; }

        public double ExpenditureTotal => Expenditures?.Sum(x => x.Amount) ?? 0;

        #endregion
    }
}