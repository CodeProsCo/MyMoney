namespace MyMoney.Helpers.Export.Csv
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    ///     The <see cref="CsvGenerator" /> class is used for generating CSV (comma separated value) representations of
    ///     objects.
    /// </summary>
    public class CsvGenerator
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="CsvGenerator" /> class.
        /// </summary>
        public CsvGenerator()
        {
            Headers = new List<string>();
            Rows = new List<CsvRow>();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the headers.
        /// </summary>
        /// <value>
        ///     The headers.
        /// </value>
        private IList<string> Headers { get; set; }

        /// <summary>
        ///     Gets or sets the rows.
        /// </summary>
        /// <value>
        ///     The rows.
        /// </value>
        private IList<CsvRow> Rows { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a header.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <returns>This instance, for function chaining.</returns>
        public CsvGenerator AddHeader(string header)
        {
            Headers.Add(header);

            return this;
        }

        /// <summary>
        /// Adds multiple headers.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <returns>This instance, for function chaining.</returns>
        public CsvGenerator AddHeaders(IEnumerable<string> headers)
        {
            foreach (var header in headers)
            {
                Headers.Add(header);
            }

            return this;
        }

        /// <summary>
        /// Creates a comma separated row.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="ignoreHeaderCount">
        /// If false, an <see cref="ArgumentNullException"/> is thrown when the number of items exceeds that of the number of headers.
        /// </param>
        /// <returns>
        /// This instance, for function chaining.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Exception thrown if the size of the row is greater than the number of headers.
        /// </exception>
        public CsvGenerator CreateRow(IList<string> items, bool ignoreHeaderCount = true)
        {
            if (items.Count > Headers.Count && !ignoreHeaderCount)
            {
                throw new ArgumentOutOfRangeException(nameof(items));
            }

            var row = new CsvRow(items);

            Rows.Add(row);

            return this;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var headerLine = string.Empty;
            var body = string.Empty;

            foreach (var header in Headers)
            {
                if (header == Headers.Last())
                {
                    headerLine += $"{header}\n";
                    continue;
                }

                headerLine += $"{header},";
            }

            body = Rows.Aggregate(body, (current, row) => current + $"{row}\n");

            return $"{headerLine}{body}";
        }

        #endregion
    }
}