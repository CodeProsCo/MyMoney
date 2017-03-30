namespace MyMoney.Proxies.Spending
{
    #region Usings

    using System;

    using MyMoney.Proxies.Common;

    #endregion

    /// <summary>
    ///     The proxy class for expenditures.
    /// </summary>
    public class ExpenditureProxy
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public double Amount { get; set; }

        /// <summary>
        ///     Gets or sets the category.
        /// </summary>
        /// <value>
        ///     The category.
        /// </value>
        public CategoryProxy Category { get; set; }

        /// <summary>
        ///     Gets or sets the category identifier.
        /// </summary>
        /// <value>
        ///     The category identifier.
        /// </value>
        public Guid CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the date occurred.
        /// </summary>
        /// <value>
        ///     The date occurred.
        /// </value>
        public DateTime DateOccurred { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        #endregion
    }
}