public class Queue<T> : IQueue<T>
{
    private List<T> queue = new List<T>();
    public void Add(T item) 
    { queue.Add(item); }
    public T Delete() 
    {
        T firstItem = queue[0];
        queue.RemoveAt(0);
        return firstItem;
    }
    public T Choose() { return queue[0]; }
    public bool isEmpty() { return queue.Count == 0; }
    public int Size() { return queue.Count; }
}

