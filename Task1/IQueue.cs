namespace Task1
{
    using System;
    public interface IQueue<T>
    {
        void Add(T item);
        T Delete();
        T Choose();
        bool isEmpty();
        int Size();
    }
}
