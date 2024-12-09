using Task2;

namespace Task3
{
    class TestCarStation
    {
        public static void Main(string[] args)
        {
            // Creating station instances
            var peopleGasStation = new PeopleGasStation();
            var peopleElectricStation = new PeopleElectricStation();
            var robotGasStation = new RobotGasStation();
            var robotElectricStation = new RobotElectricStation();

            // Creating cars with different types and passengers
            var car1 = new Car("Car1", true, "GAS", "ROBOTS", 10);  // Needs both dining and gas refuel
            var car2 = new Car("Car2", false, "ELECTRIC", "PEOPLE", 11);  // Needs only electric refuel
            var car3 = new Car("Car3", true, "ELECTRIC", "PEOPLE", 5); // Needs dining only
            var car4 = new Car("Car4", false, "GAS", "PEOPLE", 50);    // Needs neither

            // Testing car routing for each station
            TestStation(peopleGasStation, car1);
            TestStation(peopleElectricStation, car2);
            TestStation(robotGasStation, car3);
            TestStation(robotElectricStation, car4);
        }

        private static void TestStation(CarStation station, Car car)
        {
            Console.WriteLine($"\nTesting {station.Name} with {car.CarId}:");

            if (car.NeedsDinner && station is IDineable dineableStation)
            {
                Console.WriteLine($"{car.CarId} needs food.");
                dineableStation.ServeFood(car.Passengers);
            }

            if (station is IRefuelable refuelableStation)
            {
                Console.WriteLine($"{car.CarId} needs refueling.");
                refuelableStation.Refuel(car.FuelType);
            }

        }
    }
}
