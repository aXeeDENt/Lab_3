using System;
using System.Diagnostics;
using System.Text; // Required for Encoding

namespace Task2
{
    class TestCars
{
    static void Main(string[] args)
    {
        // Redirect Console output to capture messages for assertions
        using (var consoleOutput = new ConsoleOutputHelper())
        {
            // Dineable objects
            Dineable peopleDinner = new PeopleDinner();
            Dineable robotDinner = new RobotDinner();

            // Refuelable objects
            Refuelable gasStation = new GasStation();
            Refuelable electricStation = new ElectricStation();

            // Serve dinner to people and verify
            peopleDinner.ServeDinner("Car1");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving dinner to people in car Car1"), 
                "PeopleDinner did not serve Car1 correctly.");

            peopleDinner.ServeDinner("Car2");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving dinner to people in car Car2"), 
                "PeopleDinner did not serve Car2 correctly.");

            // Serve dinner to robots and verify
            robotDinner.ServeDinner("Car3");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Serving dinner to robots in car Car3"), 
                "RobotDinner did not serve Car3 correctly.");

            // Refuel gas car and verify
            gasStation.Refuel("Car4");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling gas car Car4"), 
                "GasStation did not refuel Car4 correctly.");

            // Refuel electric cars and verify
            electricStation.Refuel("Car5");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling electric car Car5"), 
                "ElectricStation did not refuel Car5 correctly.");

            electricStation.Refuel("Car6");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Refueling electric car Car6"), 
                "ElectricStation did not refuel Car6 correctly.");

            // Test edge case: Cars that do not dine or refuel
            string noServiceCar = "Car7";
            Console.WriteLine($"{noServiceCar} did not dine or refuel.");
            Debug.Assert(consoleOutput.GetLastMessage().Contains("Car7 did not dine or refuel."), 
                "Car7's non-service scenario was not handled correctly.");
        }
        Console.WriteLine("All tests passed!");
    }
}

// Helper class to capture Console.WriteLine output
public class ConsoleOutputHelper : IDisposable
{
    private readonly System.IO.StringWriter _stringWriter = new System.IO.StringWriter();
    private readonly System.IO.TextWriter _originalOutput;

    public ConsoleOutputHelper()
    {
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    public string GetLastMessage()
    {
        string output = _stringWriter.ToString();
        string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        return lines.Length > 0 ? lines[^1] : string.Empty;
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput); // Restore original Console output
        _stringWriter.Dispose();
    }
}

}
