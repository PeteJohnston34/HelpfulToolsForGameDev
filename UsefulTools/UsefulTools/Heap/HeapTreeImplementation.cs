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
        public bool IsEmpty { get { return _rootNode == null; } }

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
                _nodeCount = 0;
                return element;
            }

            HeapNode<K, T> lastNode = _rootNode.pop(Level, Offset);
            _rootNode.Element = lastNode.Element;
            _rootNode.Key = lastNode.Key;

            //Decrement nodecount after pop() but before heapDown()
            _nodeCount--;

            heapDown();

            return element;
        }

        public void heapDown()
        {
            _rootNode.heapDown(Level);
        }

        public T peek()
        {      
            return _rootNode.Element;
        }
    }
}
