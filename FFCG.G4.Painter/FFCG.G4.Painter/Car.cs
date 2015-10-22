using System.Drawing;

namespace FFCG.G4.Painter
{
    public class Car
    {
        public string RegistrationNumber { get; set; }
        public Color Color { get; set; }

        public Car(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
            Color = Color.Gray;


        }
    }
}