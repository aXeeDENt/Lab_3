using System;
using Task2;

namespace Task3
{
    public class Car
{
    public string CarId { get; private set; }
    public bool NeedsDinner { get; private set; }
    public bool NeedsRefuel { get; private set; }

    public Car(string carId, bool needsDinner, bool needsRefuel)
    {
        CarId = carId;
        NeedsDinner = needsDinner;
        NeedsRefuel = needsRefuel;
    }
}
}

