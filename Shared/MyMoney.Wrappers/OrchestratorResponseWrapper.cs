namespace MyMoney.Wrappers
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// The <see cref="OrchestratorResponseWrapper{T}"/> class contains the response from an orchestrator, whether it was successful and if it encountered any warnings or errors.
    /// </summary>
    /// <typeparam name="T">The response type.</typeparam>
    public class OrchestratorResponseWrapper<T>
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrchestratorResponseWrapper{T}"/> class.
        /// </summary>
        public OrchestratorResponseWrapper()
        {
            Errors = new List<ResponseErrorWrapper>();
            Warnings = new List<string>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IList<ResponseErrorWrapper> Errors { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public T Model { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="OrchestratorResponseWrapper{T}"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success => !Errors?.Any() ?? true;

        /// <summary>
        /// Gets or sets the warnings.
        /// </summary>
        /// <value>
        /// The warnings.
        /// </value>
        public IList<string> Warnings { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="error">The error.</param>
        public void AddError(ResponseErrorWrapper error)
        {
            Errors.Add(error);
        }

        /// <summary>
        /// Adds the errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public void AddErrors(IEnumerable<ResponseErrorWrapper> errors)
        {
            foreach (var error in errors)
            {
                AddError(error);
            }
        }

        /// <summary>
        /// Adds the warnings.
        /// </summary>
        /// <param name="warnings">The warnings.</param>
        public void AddWarnings(IEnumerable<string> warnings)
        {
            foreach (var warn in warnings)
            {
                AddWarning(warn);
            }
        }

        /// <summary>
        /// Adds the warning.
        /// </summary>
        /// <param name="warn">The warn.</param>
        private void AddWarning(string warn)
        {
            Warnings.Add(warn);
        }

        #endregion
    }
}