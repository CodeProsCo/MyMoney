namespace MyMoney.ViewModels.Spending.Bills.Enum
{
    #region Usings

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    /// <summary>
    ///     The <see cref="TimePeriod" /> enumeration determines a period of time.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimePeriod
    {
        /// <summary>
        ///     The event happens daily.
        /// </summary>
        Daily = 0, 

        /// <summary>
        ///     The event happens weekly.
        /// </summary>
        Weekly, 

        /// <summary>
        ///     The event happens monthly.
        /// </summary>
        Monthly, 

        /// <summary>
        ///     The event happens yearly.
        /// </summary>
        Yearly
    }
}