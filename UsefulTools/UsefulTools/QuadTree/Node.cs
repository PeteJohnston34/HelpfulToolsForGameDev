using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UsefulTools.QuadTree
{
    public abstract class Node<T> : IHasRect
    {
        public abstract Rectangle Rect { get; }

        public abstract void add(T entity);
        public abstract void print(string indent);
    }
}
