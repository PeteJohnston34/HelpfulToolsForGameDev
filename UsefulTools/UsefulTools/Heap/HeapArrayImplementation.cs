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

        //constructors
        public HeapArrayImplementation(HeapArrayPriorityType priorityType)
        {
            _count = 0;
            _depth = 0;
            _heap = new T[1];
            _priorityType = priorityType;
        }

        public HeapArrayImplementation(T[] arrayToHeap, HeapArrayPriorityType priorityType)
        {
            _count = arrayToHeap.Length;
            _depth = (int)Math.Floor(Math.Log(_count) / Math.Log(2));
            _heap = new T[(int)Math.Pow(2, _depth)];
            _priorityType = priorityType;
        }

        //public methods
        public void push(T element)
        {
            if(_count == _heap.Length) { doubleHeap(); }
            //TODO: Finish implementing
        }

        //private methods
        private void doubleHeap()
        {
            T[] tempArr = new T[_heap.Length * 2];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = _heap[i];
            }
            _heap = tempArr;         
        }
    }
}
