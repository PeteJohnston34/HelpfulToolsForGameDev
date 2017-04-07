﻿using System;
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
        public abstract void remove(T entity);
        public abstract void print(string indent);
        public abstract List<T> queryArea(Rectangle areaToQuery, List<T> entitiesFound);
        public abstract void checkChildren();
    }
}
