using System.Drawing;

namespace FFCG.G4.Painter
{
    public class Painter
    {
        public void Paint(Car car, Color color)
        {
            car.Color = color;
        }
    }
}