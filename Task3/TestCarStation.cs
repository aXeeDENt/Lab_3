using Task2;

namespace Task3
{
    class TestCarStation
    {
        public static void Main(string[] args)
        {
            var peopleGasStation = new PeopleGasStation();
            var peopleElectricStation = new PeopleElectricStation();
            var robotGasStation = new RobotGasStation();
            var robotElectricStation = new RobotElectricStation();

            var car1 = new Car(1, "GAS", "ROBOTS", true, 10);  
            var car2 = new Car(2, "ELECTRIC", "PEOPLE", false, 11);  
            var car3 = new Car(3, "ELECTRIC", "PEOPLE", true, 5); 
            var car4 = new Car(4, "GAS", "PEOPLE", false, 50);    

            TestStation(peopleGasStation, car1);
            TestStation(peopleElectricStation, car2);
            TestStation(robotGasStation, car3);
            TestStation(robotElectricStation, car4);
        }

        private static void TestStation(CarStation station, Car car)
        {
            Console.WriteLine($"\nTesting {station.Name} with {car.id}:");

            if (car.isDining && station is IDineable dineableStation)
            {
                Console.WriteLine($"{car.id} needs food.");
                dineableStation.ServeFood(car.passengers);
            }

            if (station is IRefuelable refuelableStation)
            {
                Console.WriteLine($"{car.id} needs refueling.");
                refuelableStation.Refuel(car.type);
            }

        }
    }
}
