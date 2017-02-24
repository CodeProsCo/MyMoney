using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.Orchestrators.Spending
{
    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    [UsedImplicitly]
    public class BillOrchestrator : IBillOrchestrator
    {
        public readonly IBillAssembler assembler;

        public readonly IBillRepository repository;

        public BillOrchestrator(IBillAssembler assembler, IBillRepository repository)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.assembler = assembler;
            this.repository = repository;
        }

        #region Implementation of IBillOrchestrator

        public async Task<GetBillInformationResponse> GetBillInformation(GetBillInformationRequest request)
        {
            var response = new GetBillInformationResponse();

            try
            {
                var bills = await repository.BetBillsForUser(request.UserId);

                response = assembler.NewGetBillInformationResponse(bills, request.RequestReference);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }

            return response;
        }

        public async Task<AddBillResponse> AddBill(AddBillRequest request)
        {
            var response = new AddBillResponse();

            try
            {
                var dataModel = assembler.NewBillDataModel(request.Bill);
                var bills = await repository.AddBill(dataModel);

                response = assembler.NewAddBillResponse(bills, request.RequestReference);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }

            return response;
        }

        #endregion
    }
}
