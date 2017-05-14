namespace MyMoney.Helpers.Export.Csv
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// The <see cref="CsvRow"/> class is used to generate a comma separated row for use in a CSV file.
    /// </summary>
    public class CsvRow
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="CsvRow" /> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public CsvRow(IEnumerable<string> items)
        {
            Items = items.ToList();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        private IList<string> Items { get; }

        #endregion

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var line = string.Empty;

            foreach (var item in Items)
            {
                if (item == Items.Last())
                {
                    line += item;
                    continue;
                }

                line += $"{item},";
            }

            return line;
        }
    }
}