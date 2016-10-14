using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.FizzBuzz.Tests
{
    [TestClass]
    public class When_getting_result_items_from_FizzBuzz
    {
        private List<string> _result;

        [TestInitialize]
        public void SetUp()
        {
            var fizzBuzz = new FizzBuzz();
            _result = fizzBuzz.GetResultItems();
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
        public void Numbers_divisible_by_3_and_5_should_be_fizzbuzz()
        {
            Assert.AreEqual("FizzBuzz", _result[14]);
            Assert.AreEqual("FizzBuzz", _result[29]);
            Assert.AreEqual("FizzBuzz", _result[44]);
        }

        [TestMethod]
        public void The_first_item_should_be_1()
        {
            Assert.AreEqual("1", _result.First());
        }

        [TestMethod]
        public void The_last_item_should_be_Buzz()
        {
            Assert.AreEqual("Buzz", _result.Last());
        }

        [TestMethod]
        public void Should_contains_100_items()
        {
            Assert.AreEqual(100, _result.Count);
        }
    }
}