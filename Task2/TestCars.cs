using System.Diagnostics;
namespace Task2
{
    class TestCars
    {
        static void Main(string[] args)
        {
            using (var consoleOutput = new ConsoleOutputHelper())
            {
                var peopleGasStation = new GasStation();
                var peopleDinnerService = new PeopleDinner();
                peopleDinnerService.ServeFood("PEOPLE");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving food to people"), 
                    "PeopleGasStation did not serve food correctly.");

                var peopleElectricStation = new ElectricStation();
                var peopleElectricDinnerService = new PeopleDinner();
                peopleElectricDinnerService.ServeFood("PEOPLE");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving food to people"),
                    "PeopleElectricStation did not serve food correctly.");

                var gasStation = new GasStation();
                gasStation.Refuel("GAS");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling with Gas"),
                    "PeopleGasStation did not refuel with Gas correctly.");

                var electricStation = new ElectricStation();
                electricStation.Refuel("ELECTRIC");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling with Electric"),
                    "PeopleElectricStation did not refuel with Electric correctly.");

                var robotGasStation = new GasStation();
                var robotDinnerService = new RobotDinner();
                robotDinnerService.ServeFood("ROBOTS");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving food to robots"),
                    "RobotGasStation did not serve food correctly.");

                var robotElectricStation = new ElectricStation();
                var robotElectricDinnerService = new RobotDinner();
                robotElectricDinnerService.ServeFood("ROBOTS");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving food to robots"),
                    "RobotElectricStation did not serve food correctly.");

                var robotGasRefuelStation = new GasStation();
                robotGasRefuelStation.Refuel("GAS");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling with Gas"),
                    "RobotGasStation did not refuel with Gas correctly.");

                var robotElectricRefuelStation = new ElectricStation();
                robotElectricRefuelStation.Refuel("ELECTRIC");  
                Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling with Electric"),
                    "RobotElectricStation did not refuel with Electric correctly.");
            }

            Console.WriteLine("All tests passed!");
        }
    }
}
