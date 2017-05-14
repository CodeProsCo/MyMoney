namespace MyMoney.API.Orchestrators
{
    #region Usings

    using System;

    using Helpers.Error.Interfaces;

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

        #endregion
    }
}