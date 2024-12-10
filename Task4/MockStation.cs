using System;
using System.Collections.Generic;
using Task3;
using Task2;

public class MockCarStation : CarStation, IRefuelable, IDineable
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
        Console.WriteLine($"MockCarStation {Name}: ServeFood called with passengers: {passengers}");
        onDine?.Invoke(Name);
    }

    public void Refuel(string fuelType)
    {
        Console.WriteLine($"MockCarStation {Name}: Refuel called with fuel type: {fuelType}");
        onRefuel?.Invoke(Name);
    }

    // Implement the abstract ServeCars method
    public override void ServeCars()
    {
        while (CarsQueue.Count > 0)
        {
            var car = CarsQueue.Dequeue();
            if (car.isDining)
            {
                ServeFood(car.passengers);
            }
            else
            {
                Refuel(car.type);
            }
            Console.WriteLine($"MockCarStation {Name}: Car {car.id} served.");
        }
    }
}
