namespace MyMoney.Web.Orchestrators
{
    #region Usings

    using System;

    using Helpers.Error.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="BaseOrchestrator" /> is the parent class for all orchestrators in the web application.
    /// </summary>
    public class BaseOrchestrator
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOrchestrator"/> class.
        /// </summary>
        /// <param name="errorHelper">The error helper.</param>
        /// <exception cref="System.ArgumentNullException">errorHelper
        /// Exception thrown if the error helper is null.
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
        /// <value>
        ///     The error helper.
        /// </value>
        protected IErrorHelper ErrorHelper { get; }

        #endregion
    }
}