namespace MyMoney.ViewModels.Spending.Bills.Enum
{
    #region Usings

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimePeriod
    {
        Daily = 0, 

        Weekly, 

        Monthly, 

        Yearly
    }
}