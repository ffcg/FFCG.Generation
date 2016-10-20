using NUnit.Framework;

namespace FFCG.G5.FizzBuzzer.Tests
{
    [TestFixture]
    public class DivisbleByFiveTests
    {
        private DivisibleByFive _rule;

        [SetUp]
        public void SetUp()
        {
            _rule = new DivisibleByFive();
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(25)]
        public void Should_match_number_divisble_by_five(int number)
        {
            bool isMatch = _rule.Matches(number);

            Assert.True(isMatch);
        }

        [Test]
        public void Result_should_be_Buzz()
        {
            string result = _rule.Result;

            Assert.AreEqual("Buzz", result);
        }
    }
}