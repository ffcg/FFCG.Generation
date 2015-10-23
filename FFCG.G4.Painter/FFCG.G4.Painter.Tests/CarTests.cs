using System.Drawing;
using NUnit.Framework;

namespace FFCG.G4.Painter.Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car _car;

        [SetUp]
        public void SetUp()
        {
            _car = new Car("REG-NUMBER", CarType.Sedan);
        }

        [Test]
        public void Car_should_have_a_registration_number_when_created()
        {
            Assert.AreEqual("REG-NUMBER", _car.RegistrationNumber);
        }

        [Test]
        public void Car_should_have_a_type_when_created()
        {
            Assert.AreEqual(CarType.Sedan, _car.Type);
        }

        [Test]
        public void Car_should_have_default_color_of_gray()
        {
            Assert.AreEqual(Color.Gray, _car.Color);
        }
    }
}