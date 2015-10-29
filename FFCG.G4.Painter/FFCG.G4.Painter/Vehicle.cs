using System.Drawing;

namespace FFCG.G4.Painter
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public Color Color { get; set; }

        public Vehicle(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
            Color = Color.Gray;
        }
    }
}