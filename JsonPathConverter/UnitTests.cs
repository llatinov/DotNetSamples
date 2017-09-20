using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using FluentAssertions;

namespace JsonPathConverter
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestJsonPathDeserialization()
        {
            var fileContent = File.ReadAllText("jsonFile.json");
            var result = JsonConvert.DeserializeObject<JsonModel>(fileContent);

            result.Node1Array.Should().BeEquivalentTo(new List<string> { "value1", "value2" });
            result.Node2.Should().Be(true);
            result.Node3Array.Should().BeEquivalentTo(new List<int> { 1, 2, 3 });
            result.Node4.NestedNode2.Should().Be("n4n1value");
        }
    }
}