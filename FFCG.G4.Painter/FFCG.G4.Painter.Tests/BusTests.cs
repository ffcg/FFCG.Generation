using System.Drawing;
using NUnit.Framework;

namespace FFCG.G4.Painter.Tests
{
    [TestFixture]
    public class BusTests
    {
        private Bus _bus;

        [SetUp]
        public void SetUp()
        {
            _bus = new Bus("REG-NUMBER");
        }

        [Test]
        public void Bus_should_have_a_registration_number_when_created()
        {
            Assert.AreEqual("REG-NUMBER", _bus.RegistrationNumber);
        }

        [Test]
        public void Bus_should_have_default_color_of_gray()
        {
            Assert.AreEqual(Color.Gray, _bus.Color);
        }
    }
}