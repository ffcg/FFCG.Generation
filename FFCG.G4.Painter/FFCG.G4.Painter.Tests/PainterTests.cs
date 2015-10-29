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
            var car = new Car("REG", CarType.Sedan);
            painter.Paint(car, Color.HotPink);

            Assert.AreEqual(Color.HotPink, car.Color);
        }

        [Test]
        public void Painter_should_paint_bus_with_given_color()
        {
            var painter = new Painter();
            var bus = new Bus("REG");
            painter.Paint(bus, Color.HotPink);

            Assert.AreEqual(Color.HotPink, bus.Color);
        }

        [Test]
        public void Painter_should_paint_tank_with_given_color()
        {
            var painter = new Painter();
            var tank = new Tank("REG");
            painter.Paint(tank, Color.DarkOliveGreen);

            Assert.AreEqual(Color.DarkOliveGreen, tank.Color);
        }
    }
}
