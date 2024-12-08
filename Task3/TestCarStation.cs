using Task2;

namespace Task3
{
    class TestCarStation
    {
        public static void Main(string[] args)
        {
            var carStation = new CarStation(new PeopleDinner(), new GasStation());

            carStation.AddCar(new Car("Car1", true, false));  // Needs dinner only
            carStation.AddCar(new Car("Car2", false, true)); // Needs refuel only
            carStation.AddCar(new Car("Car3", true, true));  // Needs both dinner and refuel

            carStation.ServeCars();

            // Validation output
            Console.WriteLine("All tests passed!");
        }
    }
}
