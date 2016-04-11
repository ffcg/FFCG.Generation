using System.Collections.Generic;
using FFCG.G4.Text.Manipulator.ManipulateText.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.Text.Manipulator.Tests
{
    [TestFixture]
    public class ReplaceWordTests
    {
        [Test]
        public void Should_be_able_to_replace_a_word()
        {
            var replaceWord = new ReplaceWord(new Dictionary<string, string> { { "foo", "bar" } });

            var execute = replaceWord.Manipulate("Hello foo");
            execute.Should().Be("Hello bar");
        }
    }
}