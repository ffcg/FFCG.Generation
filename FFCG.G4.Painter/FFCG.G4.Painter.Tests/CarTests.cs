using System.Drawing;
using NUnit.Framework;

namespace FFCG.G4.Painter.Tests
{
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void Car_should_have_a_registration_number_when_created()
        {
            var car = new Car("REG-NUMBER");

            Assert.AreEqual("REG-NUMBER", car.RegistrationNumber);
        }

        [Test]
        public void Car_should_have_default_color_of_gray()
        {
            var car = new Car("REG-NUMBER");

            Assert.AreEqual(Color.Gray, car.Color);
        }
    }
}