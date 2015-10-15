using NUnit.Framework;

namespace FFCG.G4.FizzBuzzKata.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void One_should_return_1()
        {
            string result = _fizzBuzz.GetResult(1);

            Assert.AreEqual("1", result);
        }

        [Test]
        public void Two_should_return_2()
        {
            var result = _fizzBuzz.GetResult(2);

            Assert.AreEqual("2", result);
        }

        [Test]
        public void Three_should_return_Fizz()
        {
            var result = _fizzBuzz.GetResult(3);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void Five_should_return_Buzz()
        {
            var result = _fizzBuzz.GetResult(5);

            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void Six_should_return_Fizz()
        {
            var result = _fizzBuzz.GetResult(6);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void Nine_should_return_Fizz()
        {
            var result = _fizzBuzz.GetResult(9);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void Ten_should_return_Buzz()
        {
            var result = _fizzBuzz.GetResult(10);

            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void Fifteen_should_return_FizzBuzz()
        {
            var result = _fizzBuzz.GetResult(15);
            Assert.AreEqual("FizzBuzz", result);
        }
    }
}
