namespace MyMoney.Wrappers
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class OrchestratorResponseWrapper<T>
    {
        #region Constructor

        public OrchestratorResponseWrapper()
        {
            Errors = new List<string>();
            Warnings = new List<string>();
        }

        #endregion

        #region  Properties

        public IList<string> Errors { get; set; }

        public T Model { get; set; }

        public bool Success => !Errors.Any();

        public IList<string> Warnings { get; set; }

        #endregion

        #region  Public Methods

        public void AddError(string error)
        {
            Errors.Add(error);
        }

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

        public void AddErrors(IList<string> errors)
        {
            foreach (var error in errors)
            {
                AddError(error);
            }
        }

        public void AddWarning(string warn)
        {
            Warnings.Add(warn);
        }

        public void AddWarnings(IList<string> warnings)
        {
            foreach (var warn in warnings)
            {
                AddWarning(warn);
            }
        }

        #endregion
    }
}