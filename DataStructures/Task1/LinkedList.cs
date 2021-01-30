using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class LinkedList<T> : IEnumerable<T>
    {
        class Node
        {
            public T Data { get; set; }

            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Previous = null;
                Next = null;
            } 
        }

        private Node _headNode;

        private Node _lastNode;
        public int Length { get; private set; }

        public void Add(T data)
        {
            var node = new Node(data);

            if (_headNode == null)
            {
                _headNode = node;
                _lastNode = node;
            }
            else
            {
                node.Previous = _lastNode;
                _lastNode.Next = node;
                _lastNode = node;
            }

            Length++;
        }

        public void AddAt(T data, int position)
        {
            var newNode = new Node(data);

            if (position == 0)
            {
                newNode.Next = _headNode;
                _headNode.Previous = newNode;
                _headNode = newNode;
            }
            else
            {
                var node = GetNodeAt(position);

                newNode.Next = node;
                newNode.Previous = node.Previous;
                node.Previous.Next = newNode;
                node.Previous = newNode;
            }

            Length++;
        }


        public bool Remove(T data)
        {
            if (_headNode == null)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }

            var node = GetNode(data);

            if (node == null)
            {
                return false;
            }

            var previousNode = node.Previous;
            var nextNode = node.Next;

            if (previousNode == null)
            {
                _headNode = node.Next;
                _headNode.Previous = null;
            }
            else if (nextNode == null)
            {
                previousNode.Next = null;
                _lastNode = previousNode;
            }
            else
            {
                previousNode.Next = nextNode;
                nextNode.Previous = previousNode;
            }

            Length--;
            return true;
        }

        public void RemoveAt(int position)
        {
            if (_headNode == null)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }

            var node = GetNodeAt(position);

            var previousNode = node.Previous;
            var nextNode = node.Next;

            if (previousNode == null)
            {
                _headNode = node.Next;
                _headNode.Previous = null;
            }
            else if (nextNode == null)
            {
                previousNode.Next = null;
                _lastNode = previousNode;
            }
            else
            {
                previousNode.Next = nextNode;
                nextNode.Previous = previousNode;
            }

            Length--;
        }

        public T ElementAt(int position)
        {
            var node = GetNodeAt(position);
            return node.Data;
        }

        private Node GetNodeAt(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new ArgumentOutOfRangeException($"position: {position} is invalid");
            }

            Node node;
            var currentNode = _headNode;
            int counter = 0;

            while (true)
            {
                if (counter == position)
                {
                    node = currentNode;
                    break;
                }

                counter++;
                currentNode = currentNode.Next;
            }

            return node;
        }

        private Node GetNode(T data)
        {
            var currentNode = _headNode;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _headNode;

            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
