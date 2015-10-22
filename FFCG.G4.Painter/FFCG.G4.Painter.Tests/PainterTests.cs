using System.Drawing;
using NUnit.Framework;

namespace FFCG.G4.Painter.Tests
{
    [TestFixture]
    public class PainterTests
    {
        [Test]
        public void Painter_should_paint_car_with_given_color()
        {
            var painter = new Painter();
            var car = new Car("REG");
            painter.Paint(car, Color.HotPink);

            Assert.AreEqual(Color.HotPink, car.Color);
        }
    }
}
