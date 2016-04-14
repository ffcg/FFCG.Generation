using FFCG.G4.Text.Manipulator.WriteText;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.Text.Manipulator.Tests
{
    [TestFixture]
    public class TextToStringWriterTests
    {
        [Test]
        public void Should_be_able_to_write_text_to_string()
        {
            var writer = new TextToStringWriter();
            writer.Write("foo").Should().Be("foo");
        }
    }
}