namespace MyMoney.Web.DataAccess.Spending
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class BillDataAccess : BaseDataAccess, IBillDataAccess
    {
        #region  Public Methods

        public async Task<AddBillResponse> AddBill(AddBillRequest request)
        {
            return await Post<AddBillResponse>(request);
        }

        public async Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request)
        {
            return await Delete<DeleteBillResponse>(request.FormatRequestUri(), request.Username);
        }

        public async Task<EditBillResponse> EditBill(EditBillRequest request)
        {
            return await Post<EditBillResponse>(request);
        }

        public async Task<GetBillResponse> GetBill(GetBillRequest request)
        {
            return await Get<GetBillResponse>(request.FormatRequestUri(), request.Username);
        }

        public async Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request)
        {
            return await Get<GetBillInformationResponse>(request.FormatRequestUri(), request.Username);
        }

        #endregion
    }
}