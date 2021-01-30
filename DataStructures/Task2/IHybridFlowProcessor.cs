using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public interface IHybridFlowProcessor<T>
    {
        void Push(T item);
        T Pop();
        void Enqueue(T item);
        T Dequeue();
    }
}
