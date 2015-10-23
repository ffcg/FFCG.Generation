using System.Drawing;

namespace FFCG.G4.Painter
{
    public class Car
    {
        public string RegistrationNumber { get; set; }
        public Color Color { get; set; }
        public CarType Type { get; set; }

        public Car(string registrationNumber, CarType type)
        {
            RegistrationNumber = registrationNumber;
            Type = type;
            Color = Color.Gray;
        }
    }
}