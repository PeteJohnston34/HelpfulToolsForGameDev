using System;
using UsefulTools.Heap;

namespace UsefulTools.SearchingAndSorting
{
    public class SortingAlgorithms
    {
        public static T[] HeapSort<T>(T[] dataToSort, bool isSmallToLarge) where T : IComparable
        {
            HeapArrayPriorityType priority = isSmallToLarge ? HeapArrayPriorityType.MinHeap : HeapArrayPriorityType.MaxHeap;
            HeapArrayImplementation<T> heap = new HeapArrayImplementation<T>(dataToSort, priority);

            for (int i = 0; i < dataToSort.Length; i++)
            {
                dataToSort[i] = heap.pop();
            }

            return dataToSort;
        }
    }
}
