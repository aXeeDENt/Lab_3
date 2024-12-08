namespace Task3
{
    public class Car
    {
        public string CarId { get; set; }
        public bool NeedsDinner { get; set; }
        public bool NeedsRefuel { get; set; }
        public string FuelType { get; set; }
        public string Passengers { get; set; }

        public Car(string carId, bool needsDinner, bool needsRefuel, string fuelType, string passengers)
        {
            CarId = carId;
            NeedsDinner = needsDinner;
            NeedsRefuel = needsRefuel;
            FuelType = fuelType;
            Passengers = passengers;
        }
    }
}
