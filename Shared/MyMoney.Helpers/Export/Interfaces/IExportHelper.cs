namespace MyMoney.Helpers.Export.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The interface for the <see cref="ExportHelper"/> class.
    /// </summary>
    public interface IExportHelper
    {
        /// <summary>
        /// Converts the given list of objects into CSV format.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The CSV representation of the given objects.</returns>
        string ToCsv<T>(IList<T> data);

        /// <summary>
        /// Converts the given list of objects into XML format.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The XML representation of the given objects.</returns>
        string ToXml<T>(IEnumerable<T> data);

        /// <summary>
        /// Converts the given list of objects into JSON format.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The JSON representation of the given objects.</returns>
        string ToJson<T>(IEnumerable<T> data);
    }
}