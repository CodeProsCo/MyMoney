namespace MyMoney.Helpers.Export.Json
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="JsonGenerator"/> class converts objects into a JSON file format.
    /// </summary>
    public class JsonGenerator
    {
        /// <summary>
        /// The node format
        /// </summary>
        private const string NodeFormat = "{{\n{0}\n}},\n";

        /// <summary>
        /// The property format
        /// </summary>
        private const string PropertyFormat = "\t{0}: \"{1}\",\n";

        /// <summary>
        /// The body format
        /// </summary>
        private const string BodyFormat = "{{data: [{0}]}}";

        /// <summary>
        /// The nodes
        /// </summary>
        private readonly IList<object> nodes;

        /// <summary>
        /// The node properties
        /// </summary>
        private readonly IList<string> nodeProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonGenerator"/> class.
        /// </summary>
        public JsonGenerator()
        {
            nodes = new List<object>();
            nodeProperties = new List<string>();
        }

        /// <summary>
        /// Adds the nodes.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>This instance, for function chaining.</returns>
        public JsonGenerator AddNodes<T>(IEnumerable<T> data)
        {
            foreach (var node in data)
            {
                nodes.Add(node);
            }

            return this;
        }

        /// <summary>
        /// Adds the node properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns>This instance, for function chaining.</returns>
        public JsonGenerator AddNodeProperties(IEnumerable<string> properties)
        {
            foreach (var prop in properties)
            {
                nodeProperties.Add(prop);
            }

            return this;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var nodesString = string.Empty;

            foreach (var item in nodes)
            {
                var properties = string.Empty;

                foreach (var prop in nodeProperties)
                {
                    var value = item.GetType().GetProperty(prop)?.GetValue(item);

                    properties += string.Format(PropertyFormat, prop, value);
                }

                var node = string.Format(NodeFormat, properties);

                nodesString += node;
            }

            return string.Format(BodyFormat, nodesString);
        }
    }
}