namespace MyMoney.ViewModels.Spending.Bills.Enum
{
    #region Usings

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BillCategory
    {
        Utilities = 0, 

        Telephone, 

        Internet, 

        Rent, 

        Insurance, 

        Vehicle
    }
}