namespace Task1
{
    public class QueueT1<T> : IQueue<T>
    {
        private List<T> queue = new List<T>();

        public void Add(T item) 
        { 
            queue.Add(item); 
            Console.WriteLine($"{item} added to queue.");
        }

        public T Delete()
        {
            if (isEmpty()) throw new InvalidOperationException("Queue is empty.");
            T firstItem = queue[0];
            queue.RemoveAt(0);
            return firstItem;
        }

        public T Choose()
        {
            if (isEmpty()) throw new InvalidOperationException("Queue is empty.");
            return queue[0];
        }

        public bool isEmpty() 
        { 
            return queue.Count == 0; 
        }

        public int Size() 
        { 
            return queue.Count; 
        }
    }
}
