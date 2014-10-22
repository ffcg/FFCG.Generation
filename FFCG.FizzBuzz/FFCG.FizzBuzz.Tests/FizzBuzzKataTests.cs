using System;
using System.Collections.Generic;
using System.Linq;
using FFCG.FizzBuzz.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzKataTests
    {
        private FizzBuzzKata _kata;

        [SetUp]
        public void SetUp()
        {
            _kata = new FizzBuzzKata(new List<IDivisbleRule>
                        {
                            new DivisibleByThree(),
                            new DivisibleByFive()
                        });
        }

        [Test]
        public void Zero_should_give_fizzbuzz()
        {
            var answer = _kata.Answer(0);
            answer.Should().Be("fizzbuzz");
        }

        [Test]
        public void Three_should_give_fizz()
        {
            var answer = _kata.Answer(3);
            answer.Should().Be("fizz");
        }

        [Test]
        public void Five_should_give_buzz()
        {
            var answer = _kata.Answer(5);
            answer.Should().Be("buzz");
        }
    }

    [TestFixture]
    public class Alternative_FizzBuzz
    {
        private FizzBuzzKata _kata;

        [SetUp]
        public void SetUp()
        {
            _kata = new FizzBuzzKata(new List<IDivisbleRule>
                        {
                            new DivisibleByThree(),
                            new DivisibleByFive(),
                            new DivisibleBySeven(),
                        });
        }

        [Test]
        public void SomeTest()
        {
            foreach (var i in Enumerable.Range(0, 99))
            {
                Console.WriteLine("{0}: {1}", i, _kata.Answer(i));
            }   
        }
    }
}