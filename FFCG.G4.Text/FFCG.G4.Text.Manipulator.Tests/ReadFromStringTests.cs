using FFCG.G4.Text.Manipulator.ReadText;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.Text.Manipulator.Tests
{
    [TestFixture]
    public class ReadFromStringTests
    {
        [Test]
        public void Should_be_able_to_read_text_from_string()
        {
            var readFromString = new ReadFromString();
            var read = readFromString.Read();
            read.Length.Should().Be(996);
        }
    }
}
