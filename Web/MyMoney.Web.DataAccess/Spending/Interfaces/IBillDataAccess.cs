namespace MyMoney.Web.DataAccess.Spending.Interfaces
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    #endregion

    public interface IBillDataAccess
    {
        #region  Public Methods

        Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request);

        #endregion
    }
}