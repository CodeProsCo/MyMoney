namespace MyMoney.API.Orchestrators.Chart
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Assemblers.Chart.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DataTransformers.Spending.Interfaces;

    using DTO.Request.Chart.Bill;
    using DTO.Request.Chart.Expenditure;
    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    ///     The <see cref="ChartOrchestrator" /> class performs actions in the API regarding charts.
    /// </summary>
    /// <seealso cref="MyMoney.API.Orchestrators.Chart.Interfaces.IChartOrchestrator" />
    [UsedImplicitly]
    public class ChartOrchestrator : BaseOrchestrator, IChartOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IChartAssembler assembler;

        /// <summary>
        ///     The bill data transformer
        /// </summary>
        private readonly IBillDataTransformer billDataTransformer;

        /// <summary>
        ///     The bill repository
        /// </summary>
        private readonly IBillRepository billRepository;

        /// <summary>
        ///     The expenditure data transformer
        /// </summary>
        private readonly IExpenditureDataTransformer expenditureDataTransformer;

        /// <summary>
        ///     The expenditure repository
        /// </summary>
        private readonly IExpenditureRepository expenditureRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartOrchestrator"/> class.
        /// </summary>
        /// <param name="assembler">
        /// The assembler.
        /// </param>
        /// <param name="billRepository">
        /// The bill repository.
        /// </param>
        /// <param name="billDataTransformer">
        /// The bill data transformer.
        /// </param>
        /// <param name="expenditureRepository">
        /// The expenditure Repository.
        /// </param>
        /// <param name="expenditureDataTransformer">
        /// The expenditure Data Transformer.
        /// </param>
        /// <param name="errorHelper">
        /// The error helper.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the assembler, repository or transformer are null.
        /// </exception>
        public ChartOrchestrator(
            IChartAssembler assembler,
            IBillRepository billRepository,
            IBillDataTransformer billDataTransformer,
            IExpenditureRepository expenditureRepository,
            IExpenditureDataTransformer expenditureDataTransformer,
            IErrorHelper errorHelper) : base(errorHelper)
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

            if (expenditureRepository == null)
            {
                throw new ArgumentNullException(nameof(expenditureRepository));
            }

            if (expenditureDataTransformer == null)
            {
                throw new ArgumentNullException(nameof(expenditureDataTransformer));
            }

            this.assembler = assembler;
            this.billRepository = billRepository;
            this.billDataTransformer = billDataTransformer;
            this.expenditureDataTransformer = expenditureDataTransformer;
            this.expenditureRepository = expenditureRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Obtains the bill category chart data from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillCategoryChartDataResponse> GetBillCategoryChartData(
            GetBillCategoryChartDataRequest request)
        {
            return await Orchestrate(async delegate {
                var bills = await billRepository.GetBillsForUser(request.UserId);
                var data = billDataTransformer.GetBillCategoryChartData(bills);

                return assembler.NewGetBillCategoryChartDataResponse(data, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Obtains the bill period chart data from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<GetBillPeriodChartDataResponse> GetBillPeriodChartData(GetBillPeriodChartDataRequest request)
        {
            return await Orchestrate(async delegate {
                var bills = await billRepository.GetBillsForUser(request.UserId);
                var data = billDataTransformer.GetBillPeriodChartData(bills);

                return assembler.NewGetBillPeriodChartDataResponse(data, request.RequestReference);
            }, request);
        }

        /// <summary>
        ///     Obtains the data required for the expenditure chart.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        public async Task<GetExpenditureChartDataResponse> GetExpenditureChartData(
            GetExpenditureChartDataRequest request)
        {
            return await Orchestrate(async delegate {
                var expenditure = await expenditureRepository.GetExpenditureForUserForMonth(request.UserId);
                var data = expenditureDataTransformer.GetRollingExpenditureSum(expenditure);

                return assembler.NewGetExpenditureChartDataResponse(data, request.RequestReference);
            }, request);
        }

        #endregion
    }
}