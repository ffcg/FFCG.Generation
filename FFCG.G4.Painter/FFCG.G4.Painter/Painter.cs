using System.Drawing;

namespace FFCG.G4.Painter
{
    public class Painter
    {
        public void Paint(Vehicle vehicle, Color color)
        {
            vehicle.Color = color;
        }
    }
}