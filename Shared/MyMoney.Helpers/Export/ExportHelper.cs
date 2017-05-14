namespace MyMoney.Helpers.Export
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Csv;

    using Interfaces;

    using JetBrains.Annotations;

    using Xml;

    #endregion

    /// <summary>
    /// The <see cref="ExportHelper"/> class contains helper methods to convert objects into CSV, JSON and XML formats.
    /// </summary>
    /// <seealso cref="MyMoney.Helpers.Export.Interfaces.IExportHelper" />
    [UsedImplicitly]
    public class ExportHelper : IExportHelper
    {
        #region Methods

        /// <summary>
        /// Converts the given list of objects into CSV format.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The CSV representation of the given objects.</returns>
        public string ToCsv<T>(IList<T> data)
        {
            var properties = GetCleanObjectProperties(data.First());
            var propertyNames = properties.Select(x => x.Name).ToArray();

            var generator = new CsvGenerator().AddHeaders(propertyNames);

            foreach (var item in data)
            {
                var values = properties.Select(
                    property => property.GetValue(item).ToString()).ToList();

                generator.CreateRow(values, false);
            }

            return generator.ToString();
        }

        /// <summary>
        /// Converts the given list of objects into XML format.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>
        /// The XML representation of the given objects.
        /// </returns>
        public string ToXml<T>(IList<T> data)
        {
            var properties = GetCleanObjectProperties(data.First());
            var propertyNames = properties.Select(x => x.Name).ToArray();

            var generator = new XmlGenerator().AddNodeProperties(propertyNames).AddNodes(data);
        }

        /// <summary>
        /// Converts the given list of objects into JSON format.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>
        /// The JSON representation of the given objects.
        /// </returns>
        public string ToJson<T>(IEnumerable<T> data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the properties of the given object, excluding those that we do not want to be in the CSV files (such as ids etc.).
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The list of properties.</returns>
        private static List<PropertyInfo> GetCleanObjectProperties(object item)
        {
            var type = item.GetType();
            var properties = type.GetProperties();

            return properties.Where(x => !x.Name.ToLowerInvariant().Contains("id")).ToList();
        }

        #endregion
    }
}