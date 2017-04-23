using System;

namespace UsefulTools.Heap
{
    public enum HeapArrayPriorityType { MaxHeap, MinHeap }

    public class HeapArrayImplementation<T> where T : IComparable
    {
        //members
        private int _count;
        private int _depth;
        private T[] _heap;
        private HeapArrayPriorityType _priorityType;

        //properties
        public bool IsEmpty { get { return _count == 0; } }
        public HeapArrayPriorityType PriorityType { get { return _priorityType; } }        

        //constructors
        public HeapArrayImplementation(HeapArrayPriorityType priorityType)
        {
            _count = 0;
            _depth = 0;
            _heap = new T[1];
            _priorityType = priorityType;
        }

        public HeapArrayImplementation(T[] arrayToHeap, HeapArrayPriorityType priorityType) : this(priorityType)
        {
            for (int i = 0; i < arrayToHeap.Length; i++)
            {
                push(arrayToHeap[i]);
            }
        }

        //public methods
        public void push(T element)
        {
            if(_count == _heap.Length) { doubleHeap(); }

            _heap[_count] = element;
            heapUp(_count);
            _count++;
        }

        public T pop()
        {
            T element = _heap[0];
            _heap[0] = _heap[_count - 1];
            heapDown(0);
            _count--;
            if(_count == _heap.Length / 2) { halfHeap(); }

            return element;
        }

        //private methods
        private void heapUp(int index)
        {
            if(index == 0) { return; }

            int parentIndex = (index - 1) / 2;
            if(_priorityType == HeapArrayPriorityType.MaxHeap && _heap[index].CompareTo(_heap[parentIndex]) > 0 ||
                _priorityType == HeapArrayPriorityType.MinHeap && _heap[index].CompareTo(_heap[parentIndex]) < 0)
            {
                swap(index, parentIndex);
                heapUp(parentIndex);
            }
        }

        private void heapDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int childToCheck;
            
            if(_count < leftChildIndex + 1) { return; }

            if (_count == leftChildIndex + 1) { childToCheck = leftChildIndex; }
            else
            {
                if (_priorityType == HeapArrayPriorityType.MaxHeap)
                {
                    childToCheck = _heap[leftChildIndex].CompareTo(_heap[leftChildIndex + 1]) > 0 ?
                        leftChildIndex : leftChildIndex + 1;
                }
                else
                {
                    childToCheck = _heap[leftChildIndex].CompareTo(_heap[leftChildIndex + 1]) <= 0 ?
                        leftChildIndex : leftChildIndex + 1;
                }
            }

            if (_priorityType == HeapArrayPriorityType.MaxHeap && _heap[childToCheck].CompareTo(_heap[index]) > 0 ||
                _priorityType == HeapArrayPriorityType.MinHeap && _heap[childToCheck].CompareTo(_heap[index]) < 0)
            {
                swap(childToCheck, index);
                heapDown(childToCheck);
            }
        }

        private void swap(int index1, int index2)
        {
            T temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        private void doubleHeap()
        {
            _depth++;
            T[] tempArr = new T[_heap.Length + (int)Math.Pow(2,_depth)];
            for (int i = 0; i < _heap.Length; i++)
            {
                tempArr[i] = _heap[i];
            }
            _heap = tempArr;         
        }

        private void halfHeap()
        {
            T[] tempArr = new T[_heap.Length - (int)Math.Pow(2, _depth)];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = _heap[i];
            }
            _depth--;
            _heap = tempArr;
        }
    }
}
