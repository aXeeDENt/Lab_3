namespace Task2
{
    public class PeopleDinner : IDineable
    {
        public void ServeFood(string passengers)
        {
            if (passengers == "PEOPLE")
            {
                Console.WriteLine("Serving food to people.");
            }
            else
            {
                Console.WriteLine("This station only serves food to people.");
            }
        }
    }

    public class RobotDinner : IDineable
    {
        public void ServeFood(string passengers)
        {
            if (passengers == "ROBOTS")
            {
                Console.WriteLine("Serving food to robots.");
            }
            else
            {
                Console.WriteLine("This station only serves food to robots.");
            }
        }
    }

    public class GasStation : IRefuelable
    {
        public void Refuel(string type)
        {
            if (type == "GAS")
            {
                Console.WriteLine("Refueling with Gas.");
            }
            else
            {
                Console.WriteLine("This station doesn't provide Electric fueling.");
            }
        }
    }

    public class ElectricStation : IRefuelable
    {
        public void Refuel(string type)
        {
            if (type == "ELECTRIC")
            {
                Console.WriteLine("Refueling with Electric.");
            }
            else
            {
                Console.WriteLine("This station doesn't provide Gas fueling.");
            }
        }
    }
}
