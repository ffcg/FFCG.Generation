using NUnit.Framework;

namespace FFCG.G5.FizzBuzzer.Tests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            IRule[] rules = new IRule[]
            {
                new DivisibleByMultiple(
                    new IRule[]
                    {
                        new DivisibleByThree(),
                        new DivisibleByFive()
                    }), 
                new DivisibleByThree(),
                new DivisibleByFive()
            };

            _fizzBuzz = new FizzBuzz(rules);
        }

        [Test]
        public void Divisble_by_three_returns_Fizz()
        {
            string result = _fizzBuzz.Execute(3);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void Divisble_by_five_returns_Buzz()
        {
            string result = _fizzBuzz.Execute(5);

            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void Not_divisible_by_three_or_five_should_return_number()
        {
            string result = _fizzBuzz.Execute(1);

            Assert.AreEqual("1", result);
        }

        [Test]
        public void Divisble_by_three_and_five_should_return_FizzBuzz()
        {
            string result = _fizzBuzz.Execute(15);

            Assert.AreEqual("FizzBuzz", result);
        }
    }
}