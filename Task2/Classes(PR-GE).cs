using System;
namespace Task2
{
    public class PeopleDinner : Dineable
{
    private static int peopleCount = 0;

    public override void ServeDinner(string carId)
    {
        peopleCount++;
        Console.WriteLine($"Serving dinner to people in car {carId}. Total served: {peopleCount}");
    }
}
public class RobotDinner : Dineable
{
    private static int robotCount = 0;

    public override void ServeDinner(string carId)
    {
        robotCount++;
        Console.WriteLine($"Serving dinner to robots in car {carId}. Total served: {robotCount}");
    }
}
public class GasStation : Refuelable
{
    private static int gasCarCount = 0;

    public override void Refuel(string carId)
    {
        gasCarCount++;
        Console.WriteLine($"Refueling gas car {carId}. Total refueled: {gasCarCount}");
    }
}
public class ElectricStation : Refuelable
{
    private static int electricCarCount = 0;

    public override void Refuel(string carId)
    {
        electricCarCount++;
        Console.WriteLine($"Refueling electric car {carId}. Total refueled: {electricCarCount}");
    }
}

}
