namespace MyMoney.Helpers.Export.Xml
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    ///     The <see cref="XmlGenerator" /> class converts lists of objects into XML format.
    /// </summary>
    public class XmlGenerator
    {
        /// <summary>
        ///     The attribute format
        /// </summary>
        private const string AttributeFormat = "{0}=\"{1}\" ";

        /// <summary>
        ///     The node format
        /// </summary>
        private const string NodeFormat = "\n\t<item {0} />";

        /// <summary>
        ///     The root format
        /// </summary>
        private const string RootFormat = "<root>{0}</root>";

        #region Fields

        /// <summary>
        ///     The nodes
        /// </summary>
        private readonly IList<object> nodes;

        /// <summary>
        ///     The property names
        /// </summary>
        private readonly IList<string> propertyNames;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="XmlGenerator" /> class.
        /// </summary>
        public XmlGenerator()
        {
            propertyNames = new List<string>();
            nodes = new List<object>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the node properties.
        /// </summary>
        /// <param name="props">The props.</param>
        /// <returns>This instance, for function chaining.</returns>
        public XmlGenerator AddNodeProperties(IList<string> props)
        {
            foreach (var prop in props)
            {
                propertyNames.Add(prop);
            }

            return this;
        }

        /// <summary>
        ///     Adds the nodes.
        /// </summary>
        /// <typeparam name="T">The node type.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>This instance, for function chaining.</returns>
        public XmlGenerator AddNodes<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                nodes.Add(item);
            }

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
            var nodeLines = string.Empty;

            foreach (var node in nodes)
            {
                var nodeAttributes = new Dictionary<string, object>();

                foreach (var propertyName in propertyNames)
                {
                    var value = node.GetType().GetProperty(propertyName)?.GetValue(node);

                    nodeAttributes.Add(propertyName, value);
                }

                var attributeLine = nodeAttributes.Aggregate(
                    string.Empty,
                    (current, nodeAttribute) => current + string.Format(
                                                    AttributeFormat,
                                                    nodeAttribute.Key,
                                                    nodeAttribute.Value));

                nodeLines += string.Format(NodeFormat, attributeLine);
            }

            return string.Format(RootFormat, nodeLines);
        }

        #endregion
    }
}