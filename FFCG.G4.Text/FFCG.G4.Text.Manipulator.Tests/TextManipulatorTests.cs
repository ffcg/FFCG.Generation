using System.Collections.Generic;
using FFCG.G4.Text.Manipulator.ManipulateText;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.Text.Manipulator.Tests
{
    [TestFixture]
    public class TextManipulatorTests
    {
        [Test]
        public void Should_be_able_to_execture_manipulate_rules_on_a_string()
        {
            var rule = new DummyRule();
            var rules  = new List<IManipulateTextRule> {rule};

            "test".Manipulate(rules);

            rule.TextIsManipualted.Should().BeTrue();
        }

        public class DummyRule : IManipulateTextRule
        {
            public bool TextIsManipualted { get; private set; }
            public string Manipulate(string text)
            {
                TextIsManipualted = true;
                return text;
            }
        }
    }
}