namespace MyMoney.ViewModels.Enum
{
    #region Usings

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    /// <summary>
    ///     The <see cref="Category" /> enumeration determines the category of an object.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        /// <summary>
        ///     The object is in the "Utilities" category.
        /// </summary>
        Utilities = 0,

        /// <summary>
        ///     The object is in the "Telephone" category.
        /// </summary>
        Telephone,

        /// <summary>
        ///     The object is in the "Internet" category.
        /// </summary>
        Internet,

        /// <summary>
        ///     The object is in the "Rent" category.
        /// </summary>
        Rent,

        /// <summary>
        ///     The object is in the "Insurance" category.
        /// </summary>
        Insurance,

        /// <summary>
        ///     The object is in the "Vehicle" category.
        /// </summary>
        Vehicle,

        /// <summary>
        ///     The object is in the "Mortgage" category.
        /// </summary>
        Mortgage,

        /// <summary>
        ///     The object is in the "Credit" category.
        /// </summary>
        Credit,

        /// <summary>
        ///     The object is in the "Other" category.
        /// </summary>
        Other,

        /// <summary>
        ///     The object is in the "Groceries" category.
        /// </summary>
        Groceries,

        /// <summary>
        ///     The object is in the "Entertainment" category.
        /// </summary>
        Entertaiment,

        /// <summary>
        ///     The object is in the "Clothing" category.
        /// </summary>
        Clothing,

        /// <summary>
        ///     The object is in the "Tobacco" category.
        /// </summary>
        Tobacco,

        /// <summary>
        ///     The object is in the "Alcohol" category.
        /// </summary>
        Alcohol,

        /// <summary>
        ///     The object is in the "Dining" category.
        /// </summary>
        Dining
    }
}