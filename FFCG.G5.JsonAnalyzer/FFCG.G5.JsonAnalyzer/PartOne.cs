using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.JsonAnalyzer
{
    [TestFixture]
    public class PartOne
    {
        private JsonAnalyzer _analyzer;

        [SetUp]
        public void SetUp()
        {
            _analyzer = new JsonAnalyzer();
        }

        [Test]
        [TestCase("[1,2,3]", 6)]
        [TestCase("{\"a\":2,\"b\":4}", 6)]
        [TestCase("[[[3]]]", 3)]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [TestCase("{\"a\":[-1,1]}", 0)]
        [TestCase("[-1,{\"a\":1}]", 0)]
        [TestCase("[]", 0)]
        [TestCase("{}", 0)]
        public void Should_Sum_All_Numbers(string json, int expectedSum)
        {
            _analyzer
                .GetSumOfAllNumbers(json)
                .Should()
                .Be(expectedSum);
        }

        [Test]
        public void Should_Calculate_Sum_For_Input()
        {
            _analyzer
                .GetSumOfAllNumbers(File.ReadAllText("input.json"))
                .Should()
                .Be(191164);
        }
    }
}
