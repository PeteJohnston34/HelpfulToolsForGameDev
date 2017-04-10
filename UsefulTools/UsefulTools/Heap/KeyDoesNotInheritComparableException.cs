using System;

namespace UsefulTools.Heap
{
    class KeyDoesNotInheritComparableException : Exception
    {
        public KeyDoesNotInheritComparableException(): base("The Type of key value K must implement IComparable")
        {
        }
    }
}
