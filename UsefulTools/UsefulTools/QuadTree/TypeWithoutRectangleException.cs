using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulTools.QuadTree
{
    class TypeWithoutRectangleException : Exception
    {
        public TypeWithoutRectangleException() : base("Type must implement IHasRect")
        {
        }
    }
}
