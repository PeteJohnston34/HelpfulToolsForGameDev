using System;

namespace UsefulTools.QuadTree
{
    class TypeWithoutAABBException : Exception
    {
        public TypeWithoutAABBException() : base("Type must implement IHasRect")
        {
        }
    }
}
