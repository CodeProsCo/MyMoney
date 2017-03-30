namespace MyMoney.DTO.Request.Interfaces
{
    /// <summary>
    ///     The interface for any HTTP DELETE request objects.
    /// </summary>
    public interface IDeleteRequest
    {
        #region Methods

        /// <summary>
        ///     Formats the request URI.
        /// </summary>
        /// <returns>The formatted uri.</returns>
        string FormatRequestUri();

        #endregion
    }
}