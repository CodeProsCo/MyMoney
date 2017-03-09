namespace MyMoney.ViewModels.Spending.Bills.Enum
{
    #region Usings

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    /// <summary>
    ///     The <see cref="BillCategory" /> enumeration determines the category of a bill.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BillCategory
    {
        /// <summary>
        ///     The bill is in the "Utilities" category.
        /// </summary>
        Utilities = 0, 

        /// <summary>
        ///     The bill is in the "Telephone" category.
        /// </summary>
        Telephone, 

        /// <summary>
        ///     The bill is in the "Internet" category.
        /// </summary>
        Internet, 

        /// <summary>
        ///     The bill is in the "Rent" category.
        /// </summary>
        Rent, 

        /// <summary>
        ///     The bill is in the "Insurance" category.
        /// </summary>
        Insurance, 

        /// <summary>
        ///     The bill is in the "Vehicle" category.
        /// </summary>
        Vehicle, 

        /// <summary>
        ///     The bill is in the "Mortgage" category.
        /// </summary>
        Mortgage, 

        /// <summary>
        ///     The bill is in the "Credit" category.
        /// </summary>
        Credit, 

        /// <summary>
        ///     The bill is in the "Other" category.
        /// </summary>
        Other
    }
}