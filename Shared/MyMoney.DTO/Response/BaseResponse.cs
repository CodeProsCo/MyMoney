namespace MyMoney.DTO.Response
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Wrappers;

    #endregion

    public class BaseResponse
    {
        #region Constructor

        protected BaseResponse()
        {
            Errors = new List<ResponseErrorWrapper>();
            Warnings = new List<string>();
        }

        #endregion

        #region  Properties

        public IList<ResponseErrorWrapper> Errors { get; }

        public Guid RequestReference { get; set; }

        public bool Success => Errors.Count == 0;

        public IList<string> Warnings { get; }

        #endregion

        #region  Public Methods

        public void AddError(ResponseErrorWrapper error)
        {
            Errors.Add(error);
        }

        public void AddWarning(string warning)
        {
            Warnings.Add(warning);
        }

        #endregion
    }
}