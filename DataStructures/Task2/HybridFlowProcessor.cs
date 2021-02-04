using System;
using System.Collections.Generic;
using System.Text;
using Task1;

namespace Task2
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private MyLinkedList<T> _linkedList;

        public HybridFlowProcessor()
        {
            _linkedList = new MyLinkedList<T>();
        }

        public T Dequeue()
        {
            T data = _linkedList.First.Data;

            _linkedList.RemoveFirst();

            return data;
        }

        public void Enqueue(T item)
        {
            _linkedList.Add(item);
        }

        public T Pop()
        {
            T data = _linkedList.Last.Data;

            _linkedList.RemoveLast();

            return data;
        }

        public void Push(T item)
        {
            _linkedList.Add(item);
        }
    }
}
