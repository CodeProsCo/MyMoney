namespace MyMoney.Proxies.Common
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    ///     The proxy class when transporting all category objects.
    /// </summary>
    public class CategoryProxy
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the category identifier.
        /// </summary>
        /// <value>
        ///     The category identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        #endregion

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}