using FFCG.G4.CardGame.Game.HandRules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.CardGame.Game.Tests.HandRules
{
    [TestFixture]
    public class NothingRuleTests
    {
        [Test]
        public void Should_always_be_satisfied()
        {
            var nothingRule = new NothingRule();
            var isSatisfied = nothingRule.CheckIfTheHandMeetsTheRequirements(new Hand());
            isSatisfied.Should().BeTrue();
        }
    }
}