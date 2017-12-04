using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.JsonAnalyzer
{
    [TestFixture]
    public class PartTwo
    {
        private JsonAnalyzer _analyzer;

        [SetUp]
        public void SetUp()
        {
            _analyzer = new JsonAnalyzer();
        }

        [Test]
        [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
        [TestCase("[1,2,3]", 6)]
        [TestCase("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)]
        [TestCase("[1,\"red\",5]", 6)]
        public void Should_Calculate_Sum_For_NonRed_Numbers(string json, int expectedSum)
        {
            _analyzer
                .GetSumOfAllNumbers(json, "red")
                .Should()
                .Be(expectedSum);
        }

        [Test]
        public void Should_Calculate_Sum_For_NonRed_Numbers()
        {
            _analyzer
                .GetSumOfAllNumbers(File.ReadAllText("input.json"), "red")
                .Should()
                .Be(87842);
        }
    }
}
