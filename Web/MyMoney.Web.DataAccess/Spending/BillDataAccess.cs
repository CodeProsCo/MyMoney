namespace MyMoney.Web.DataAccess.Spending
{
    #region Usings

    using System.Threading.Tasks;
    using System.Web;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using Interfaces;

    #endregion

    public class BillDataAccess : BaseDataAccess, IBillDataAccess
    {
        #region  Public Methods

        public async Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request)
        {
            return await Post<GetBillInformationResponse>(request);
        }

        public async Task<AddBillResponse> AddBill(AddBillRequest request)
        {
            return await Post<AddBillResponse>(request);
        }

        #endregion
    }
}