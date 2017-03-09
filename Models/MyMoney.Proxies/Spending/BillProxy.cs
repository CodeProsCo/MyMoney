namespace MyMoney.Proxies.Spending
{
    #region Usings

    using System;

    using Common;

    #endregion

    /// <summary>
    ///     The proxy class used when transporting bill objects.
    /// </summary>
    public class BillProxy
    {
        #region  Properties

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
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the reoccurring period.
        /// </summary>
        /// <value>
        ///     The reoccurring period.
        /// </value>
        public int ReoccurringPeriod { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>
        ///     The start date.
        /// </value>
        public DateTime StartDate { get; set; }

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