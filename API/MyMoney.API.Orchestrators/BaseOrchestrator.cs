namespace MyMoney.API.Orchestrators
{
    #region Usings

    using System;

    using Helpers.Error.Interfaces;

    using DTO.Request;
    using DTO.Response;

    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// The <see cref="BaseOrchestrator"/> class is the parent class for all API orchestrators.
    /// </summary>
    public class BaseOrchestrator
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseOrchestrator" /> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown if the error helper is null.
        /// </exception>
        protected BaseOrchestrator(IErrorHelper errorHelper)
        {
            if (errorHelper == null)
            {
                throw new ArgumentNullException(nameof(errorHelper));
            }

            ErrorHelper = errorHelper;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the error helper.
        /// </summary>
        protected IErrorHelper ErrorHelper { get; }
        
        /// <summary>
        ///     The name of the method that called the current one.
        /// </summary>
        public string CalledBy => new StackTrace().GetFrame(1).GetMethod().Name;

        #endregion

        #region Methods 

        ///     Orchestrates the specified method.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="method">The orchestrator method.</param>
        /// <param name="request">The request.</param>
        /// <returns>The response object.</returns>
        protected async Task<TResponse> Orchestrate<TRequest, TResponse>(Func<TRequest, Task<TResponse>> method, TRequest request)
            where TResponse : BaseResponse where TRequest : BaseRequest
        {
            var response = Activator.CreateInstance<TResponse>();

            try
            {
                response = await method(request);
            }
            catch (Exception ex)
            {
                var err = ErrorHelper.Create(ex, request.Username, GetType(), CalledBy);

                response.AddError(err);
            }

            return response;
        }

        #endregion
    }
}