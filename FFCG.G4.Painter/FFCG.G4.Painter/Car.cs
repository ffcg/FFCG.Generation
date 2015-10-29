namespace FFCG.G4.Painter
{
    public class Car : Vehicle
    {
        public CarType Type { get; set; }

        public Car(string registrationNumber, CarType type) : base(registrationNumber)
        {
            Type = type;
        }
    }
}