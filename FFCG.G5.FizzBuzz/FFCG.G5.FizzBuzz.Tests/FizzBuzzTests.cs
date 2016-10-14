using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        private List<string> _result;

        [TestInitialize]
        public void SetUp()
        {
            var fizzBuzz = new FizzBuzz();
            _result = fizzBuzz.GetResultSerie();
        }

        [TestMethod]
        public void Numbers_divisible_by_3_should_be_fizz()
        {
            Assert.AreEqual("Fizz", _result[2]);
            Assert.AreEqual("Fizz", _result[5]);
            Assert.AreEqual("Fizz", _result[8]);
        }

        [TestMethod]
        public void Numbers_divisible_by_5_should_be_buzz()
        {
            Assert.AreEqual("Buzz", _result[4]);
            Assert.AreEqual("Buzz", _result[9]);
            Assert.AreEqual("Buzz", _result[19]);
        }

        [TestMethod]
        public void Numbers_divisible_by_3_or_5_should_be_fizzbuzz()
        {
            Assert.AreEqual("FizzBuzz", _result[14]);
            Assert.AreEqual("FizzBuzz", _result[29]);
            Assert.AreEqual("FizzBuzz", _result[44]);
        }

        [TestMethod]
        public void Serie_should_start_with_one()
        {
            Assert.AreEqual("1", _result.First());
        }

        [TestMethod]
        public void Serie_should_ends_with_Buzz()
        {
            Assert.AreEqual("Buzz", _result.Last());
        }

        [TestMethod]
        public void Serie_should_have_count_100()
        {
            Assert.AreEqual(100, _result.Count);
        }
    }
}