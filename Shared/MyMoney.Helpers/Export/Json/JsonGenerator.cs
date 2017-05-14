namespace MyMoney.Helpers.Export.Json
{
    using System.Collections.Generic;

    public class JsonGenerator
    {
        private const string NodeFormat = "{{\n{0}\n}},\n";

        private const string PropertyFormat = "\t{0}: {1},\n";

        private const string BodyFormat = "{{[{0}]}}";

        private readonly IList<object> nodes;

        private readonly IList<string> nodeProperties;

        public JsonGenerator()
        {
            nodes = new List<object>();
            nodeProperties = new List<string>();
        }

        public JsonGenerator AddNodes<T>(IEnumerable<T> data)
        {
            foreach (var node in data)
            {
                nodes.Add(node);
            }

            return this;
        }

        public JsonGenerator AddNodeProperties(IList<string> properties)
        {
            foreach (var prop in properties)
            {
                nodeProperties.Add(prop);
            }

            return this;
        }

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