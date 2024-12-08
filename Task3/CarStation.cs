using Task1;
using Task2;

namespace Task3
{
    public class CarStation
    {
        private Dineable diningService;
        private Refuelable refuelingService;
        private IQueue<Car> carQueue;

        public CarStation(Dineable diningService, Refuelable refuelingService)
        {
            this.diningService = diningService;
            this.refuelingService = refuelingService;
            this.carQueue = new QueueT1<Car>();
        }

        public void AddCar(Car car)
        {
            carQueue.Add(car);
        }

        public void ServeCars()
        {
            while (!carQueue.isEmpty())
            {
                Car currentCar = carQueue.Delete();

                if (currentCar.NeedsDinner)
                {
                    diningService.ServeDinner(currentCar.CarId);
                }

                if (currentCar.NeedsRefuel)
                {
                    refuelingService.Refuel(currentCar.CarId);
                }

                Console.WriteLine($"Car {currentCar.CarId} served and removed from the queue.");
            }
        }
    }
}
