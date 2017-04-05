namespace MyMoney.Web.Orchestrators.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Assemblers.Chart.Interfaces;

    using DataAccess.Chart.Interfaces;

    using Helpers.Error;

    using Interfaces;

    using JetBrains.Annotations;

    using ViewModels.Enum;

    using Wrappers;

    #endregion

    /// <summary>
    ///     The <see cref="ChartOrchestrator" /> class performs actions for obtaining chart data.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Orchestrators.Chart.Interfaces.IChartOrchestrator" />
    [UsedImplicitly]
    public class ChartOrchestrator : IChartOrchestrator
    {
        #region Fields

        /// <summary>
        ///     The assembler
        /// </summary>
        private readonly IChartAssembler assembler;

        /// <summary>
        ///     The data access
        /// </summary>
        private readonly IChartDataAccess dataAccess;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChartOrchestrator" /> class.
        /// </summary>
        /// <param name="assembler">The assembler.</param>
        /// <param name="dataAccess">The data access.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the assembler or data access are null.
        /// </exception>
        public ChartOrchestrator(IChartAssembler assembler, IChartDataAccess dataAccess)
        {
            if (assembler == null)
            {
                throw new ArgumentNullException(nameof(assembler));
            }

            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }

            this.assembler = assembler;
            this.dataAccess = dataAccess;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Builds and sends an HTTP request for the data required to produce the bill category chart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<IList<KeyValuePair<string, int>>>> GetBillCategoryChartData(
            Guid userId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<IList<KeyValuePair<string, int>>>();

            try
            {
                var request = assembler.NewGetBillCategoryChartDataRequest(userId, username);
                var apiResponse = await dataAccess.GetBillCategoryChartData(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                    return response;
                }

                response.Model = apiResponse.Data;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetBillCategoryChartData");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        ///     Builds and sends an HTTP request for the data required to produce the bill period chart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<IList<KeyValuePair<TimePeriod, int>>>> GetBillPeriodChartData(
            Guid userId,
            string username)
        {
            var response = new OrchestratorResponseWrapper<IList<KeyValuePair<TimePeriod, int>>>();

            try
            {
                var request = assembler.NewGetBillPeriodChartDataRequest(userId, username);
                var apiResponse = await dataAccess.GetBillPeriodChartData(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);
                    return response;
                }

                response.Model = assembler.AssembleTimePeriodList(apiResponse.Data);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, username, GetType(), "GetBillPeriodChartData");
                response.AddError(err);
            }

            return response;
        }

        /// <summary>
        /// Builds and sends an HTTP request for the data required to produce the expenditure chart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>> GetExpenditureChartData(
            Guid userId,
            string userEmail)
        {
            var response = new OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>();

            try
            {
                var request = assembler.NewGetExpenditureChartDataRequest(DateTime.Now.Month, userId, userEmail);
                var apiResponse = await dataAccess.GetExpenditureChartData(request);

                if (!apiResponse.Success)
                {
                    response.AddErrors(apiResponse.Errors);

                    return response;
                }

                response.Model = apiResponse.Data;
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, userEmail, GetType(), "GetExpenditureChartData");
                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}