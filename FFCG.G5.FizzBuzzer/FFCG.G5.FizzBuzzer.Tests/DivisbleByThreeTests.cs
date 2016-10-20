using NUnit.Framework;

namespace FFCG.G5.FizzBuzzer.Tests
{
    [TestFixture]
    public class DivisbleByThreeTests
    {
        private DivisibleByThree _rule;

        [SetUp]
        public void SetUp()
        {
            _rule = new DivisibleByThree();
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void Should_match_number_divisble_by_three(int number)
        {
            bool isMatch = _rule.Matches(number);
            
            Assert.True(isMatch);
        }

        [Test]
        public void Result_should_be_Fizz()
        {
            string result = _rule.Result;

            Assert.AreEqual("Fizz", result);
        }
    }
}