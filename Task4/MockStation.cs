using System;
using Task3;
using Task2;

class MockCarStation : CarStation, IRefuelable, IDineable
{
    private readonly Action<string> onDine;
    private readonly Action<string> onRefuel;

    public MockCarStation(string name, Action<string> onDine = null, Action<string> onRefuel = null)
    {
        Name = name;
        this.onDine = onDine ?? (_ => { });
        this.onRefuel = onRefuel ?? (_ => { });
    }

    public void ServeFood(string passengers)
    {
        Console.WriteLine($"Mock station {Name} serving food for {passengers}.");
        onDine(Name);
    }

    public void Refuel(string fuelType)
    {
        Console.WriteLine($"Mock station {Name} refueling with {fuelType}.");
        onRefuel(Name);
    }
}
