namespace MyMoney.DTO.Response
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;

    using Wrappers;

    #endregion

    /// <summary>
    /// The <see cref="BaseResponse"/> class is the base class for all request objects.
    /// </summary>
    public class BaseResponse
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponse"/> class.
        /// </summary>
        protected BaseResponse()
        {
            Errors = new List<ResponseErrorWrapper>();
            Warnings = new List<string>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IList<ResponseErrorWrapper> Errors { get; }

        /// <summary>
        /// Gets or sets the request reference.
        /// </summary>
        /// <value>
        /// The request reference.
        /// </value>
        public Guid RequestReference { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BaseResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success => Errors.Count == 0;

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        /// <value>
        /// The warnings.
        /// </value>
        public IList<string> Warnings { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an error to the response object.
        /// </summary>
        /// <param name="error">The error.</param>
        public void AddError(ResponseErrorWrapper error)
        {
            Errors.Add(error);
        }

        /// <summary>
        /// Adds a warning to the response object.
        /// </summary>
        /// <param name="warning">The warning.</param>
        [UsedImplicitly]
        public void AddWarning(string warning)
        {
            Warnings.Add(warning);
        }

        #endregion
    }
}