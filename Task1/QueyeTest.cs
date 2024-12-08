using System.Diagnostics;
namespace Task1
{
    public class QueueTest
    {
        static void Main()
        {
            TestQueueWithIntegers();
            Console.WriteLine("All tests passed successfully");
        }

        private static void TestQueueWithIntegers()
        {
            IQueue<int> intQueue = new QueueT1<int>();

            Debug.Assert(intQueue.isEmpty(), "Queue should be empty initially.");
            Debug.Assert(intQueue.Size() == 0, "Queue size should be 0 initially.");

            intQueue.Add(10);
            intQueue.Add(20);
            intQueue.Add(30);

            Debug.Assert(!intQueue.isEmpty(), "Queue should not be empty after adding elements.");
            Debug.Assert(intQueue.Size() == 3, "Queue size should be 3 after adding three elements.");
            Debug.Assert(intQueue.Choose() == 10, "Choose() should return the first element (10).");

            int deletedItem = intQueue.Delete();
            Debug.Assert(deletedItem == 10, "Delete() should return the first element (10).");
            Debug.Assert(intQueue.Size() == 2, "Queue size should be 2 after deleting one element.");
            Debug.Assert(intQueue.Choose() == 20, "Choose() should return the new first element (20).");
        }
    }
}
