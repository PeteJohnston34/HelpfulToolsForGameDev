using System;

namespace UsefulTools.Heap
{
    public enum HeapPriorityType { MaxHeap, MinHeap}

    public class HeapTreeImplementation<K, T>
    {
        //members
        private HeapNode<K, T> _rootNode;
        private int _nodeCount;
        private static HeapPriorityType _priorityType;

        //properties
        public static HeapPriorityType PriorityType { get { return _priorityType; } }
        public int Level { get { return (int)Math.Floor(Math.Log(_nodeCount) / Math.Log(2)); } }
        public int Offset { get { return (int)(_nodeCount - (Math.Pow(2, Level) - 1)); } }

        //constructor
        public HeapTreeImplementation(HeapPriorityType priorityType)
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(K)))
            {
                throw new KeyDoesNotInheritComparableException();
            }

            _rootNode = new HeapNode<K, T>(null);
            _nodeCount = 0;
            _priorityType = priorityType;
        }

        //public methods
        public void push(K key, T element)
        {
            _nodeCount++;
            _rootNode.push(key, element, Level, Offset);
        }

        public T pop()
        {
            T element = _rootNode.Element;

            if (Level == 0)
            {
                _rootNode = null;
                return element;
            }

            HeapNode<K, T> lastNode = _rootNode.pop(Level, Offset);
            _rootNode.Element = lastNode.Element;
            _rootNode.Key = lastNode.Key;

            //Decrement nodecount after pop() but before heapDown()
            _nodeCount--;

            heapDown(Level);
            return element;
        }

        public void heapDown(int level)
        {
            _rootNode.heapDown(level);
        }

        public T peek()
        {      
            return _rootNode.Element;
        }
    }
}
