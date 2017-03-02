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

        Task<AddBillResponse> AddBill(AddBillRequest request);

        Task<GetBillResponse> GetBill(GetBillRequest request);

        Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request);

        #endregion

        Task<DeleteBillResponse> DeleteBill(DeleteBillRequest request);

        Task<EditBillResponse> EditBill(EditBillRequest request);
    }
}