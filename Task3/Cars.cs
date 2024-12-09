namespace Task3
{
    public class Car
    {
        public string CarId { get; set; }
        public bool NeedsDinner { get; set; }
        public string FuelType { get; set; }
        public string Passengers { get; set; }
        public int Consumption { get; set; }

        public Car(string carId, bool needsDinner, string fuelType, string passengers, int consumption)
        {
            CarId = carId;
            NeedsDinner = needsDinner;
            FuelType = fuelType;
            Passengers = passengers;
            Consumption = consumption;
        }
    }
}
