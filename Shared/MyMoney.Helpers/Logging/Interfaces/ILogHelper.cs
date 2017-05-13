namespace MyMoney.Helpers.Logging.Interfaces
{
    using Wrappers;

    /// <summary>
    /// The interface for the <see cref="LogHelper"/> class.
    /// </summary>
    public interface ILogHelper
    {
        /// <summary>
        /// Logs the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        void Log(ResponseErrorWrapper error);
    }
}