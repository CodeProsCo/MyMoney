namespace MyMoney.DTO.Response
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    public class BaseResponse
    {
        #region Constructor

        protected BaseResponse()
        {
            Errors = new List<string>();
            Warnings = new List<string>();
        }

        #endregion

        #region  Properties

        public IList<string> Errors { get; }

        public Guid RequestReference { get; set; }

        public bool Success => Errors.Count == 0;

        public IList<string> Warnings { get; }

        #endregion

        #region  Public Methods

        public void AddError(Exception ex)
        {
            while (true)
            {
                Errors.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    continue;
                }

                break;
            }
        }

        public void AddError(string error)
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