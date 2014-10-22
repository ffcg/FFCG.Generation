using FFCG.FizzBuzz.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.FizzBuzz.Tests
{
    [TestFixture]
    public class DivisibleByThree_Rule_Test
    {
        [Test]
        public void The_number_zero_should_be_divisble_by_three()
        {
            var rule = new DivisibleByThree();
            rule.Matches(0).Should().BeTrue();
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void Given_a_number_divisble_by_three_it_should_match(int number)
        {
            var rule = new DivisibleByThree();
            rule.Matches(number).Should().BeTrue();
        }

        [TestCase(2)]
        [TestCase(5)]
        [TestCase(8)]
        public void Given_the_a_number_not_divisble_by_three_it_should_not_match(int number)
        {
            var rule = new DivisibleByThree();
            rule.Matches(number).Should().BeFalse();
        }

        [Test]
        public void The_divisble_by_three_Word_should_be_fizz()
        {
            new DivisibleByThree().Word.Should().Be("fizz");
        }
    }
}
