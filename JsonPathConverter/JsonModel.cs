using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonPathConverter
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class JsonModel
    {
        [JsonProperty("node1.node1node2")]
        public IList<string> Node1Array { get; set; }

        [JsonProperty("node2")]
        public bool Node2 { get; set; }

        [JsonProperty("node3.node3node2.node3node2node1.node3node2node1node1")]
        public IList<int> Node3Array { get; set; }

        [JsonConverter(typeof(JsonPathConverter))]
        [JsonProperty("node4")]
        public NestedJsonModel Node4 { get; set; }
    }

    public class NestedJsonModel
    {
        [JsonProperty("node4node2")]
        public string NestedNode2 { get; set; }
    }
}