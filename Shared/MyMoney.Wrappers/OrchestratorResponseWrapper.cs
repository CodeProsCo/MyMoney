namespace MyMoney.Wrappers
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class OrchestratorResponseWrapper<T>
    {
        #region Constructor

        public OrchestratorResponseWrapper()
        {
            Errors = new List<ResponseErrorWrapper>();
            Warnings = new List<string>();
        }

        #endregion

        #region  Properties

        public IList<ResponseErrorWrapper> Errors { get; set; }

        public T Model { get; set; }

        public bool Success => !Errors?.Any() ?? true;

        public IList<string> Warnings { get; set; }

        #endregion

        #region  Public Methods

        public void AddError(ResponseErrorWrapper error)
        {
            Errors.Add(error);
        }

        public void AddErrors(IEnumerable<ResponseErrorWrapper> errors)
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