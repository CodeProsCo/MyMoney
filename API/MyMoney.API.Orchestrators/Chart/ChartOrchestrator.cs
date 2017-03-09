namespace MyMoney.API.Orchestrators.Chart
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Chart.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DataTransformers.Spending.Interfaces;

    using DTO.Request.Chart.Bill;
    using DTO.Response.Chart.Bill;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly]
    public class ChartOrchestrator : IChartOrchestrator
    {
        #region Fields

        private readonly IChartAssembler assembler;

        private readonly IBillDataTransformer billDataTransformer;

        private readonly IBillRepository billRepository;

        #endregion

        #region Constructor

        public ChartOrchestrator(
            IChartAssembler assembler, 
            IBillRepository billRepository, 
            IBillDataTransformer billDataTransformer)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (billRepository == null)
            {
                throw new ArgumentNullException(nameof(billRepository));
            }

            if (billDataTransformer == null)
            {
                throw new ArgumentNullException(nameof(billDataTransformer));
            }

            this.assembler = assembler;
            this.billRepository = billRepository;
            this.billDataTransformer = billDataTransformer;
        }

        #endregion

        #region  Public Methods

        public async Task<GetBillCategoryChartDataResponse> GetBillCategoryChartData(
            GetBillCategoryChartDataRequest request)
        {
            var response = new GetBillCategoryChartDataResponse();

            try
            {
                var bills = await billRepository.GetBillsForUser(request.UserId);
                var data = billDataTransformer.GetBillCategoryChartData(bills);

                response = assembler.NewGetBillCategoryChartDataResponse(data, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetBillCategoryChartData");
                response.AddError(err);
            }

            return response;
        }

        public async Task<GetBillPeriodChartDataResponse> GetBillPeriodChartData(GetBillPeriodChartDataRequest request)
        {
            var response = new GetBillPeriodChartDataResponse();

            try
            {
                var bills = await billRepository.GetBillsForUser(request.UserId);
                var data = billDataTransformer.GetBillPeriodChartData(bills);

                response = assembler.NewGetBillPeriodChartDataResponse(data, request.RequestReference);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), "GetBillCategoryChartData");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}