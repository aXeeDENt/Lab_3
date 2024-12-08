using System.Diagnostics;
using Task1;

namespace Task2
{
    class TestCars
    {
        static void Main(string[] args)
        {
            using (var consoleOutput = new ConsoleOutputHelper())
            {
                // Create and test dining services
                var peopleDinner = new PeopleDinner();
                peopleDinner.ServeDinner("Car1");
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving dinner to people in car Car1"),
                    "PeopleDinner did not serve Car1 correctly.");

                // Refuel and test refueling services
                var gasStation = new GasStation();
                gasStation.Refuel("Car2");
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling gas car Car2"),
                    "GasStation did not refuel Car2 correctly.");
            }

            Console.WriteLine("All tests passed!");
        }
    }
}
