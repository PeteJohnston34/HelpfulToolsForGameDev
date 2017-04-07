using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace UsefulTools.QuadTree
{
    //A QuadTree Implementation for use with Monogame.
    //Type T must implement IHasRect
    public class QuadTreeImplementation<T> : Node<T>
    {
        //members
        private StandardNode<T> _root;
        private Rectangle _rectangle;

        //properties
        public override Rectangle Rect { get { return _rectangle; } }

        //constructor
        public QuadTreeImplementation(Rectangle rectangle)
        {
            if (!typeof(IHasRect).IsAssignableFrom(typeof(T)))
            {
                throw new TypeWithoutRectangleException();
            }

            _rectangle = rectangle;
            _root = new StandardNode<T>(rectangle, this);
        }

        //public methods
        public override void add(T entity)
        {
            _root.add(entity);
        }

        public override void remove(T entity)
        {
            IHasRect entityRect = (IHasRect)entity;
            if (entityRect.Rect.Intersects(Rect)) { _root.remove(entity); }
        }

        public override void print(string indent = "")
        {
            Console.WriteLine("Tree Contents:");
            _root.print(indent);
        }

        public override List<T> queryArea(Rectangle areaToQuery, List<T> entitiesFound = null)
        {
            return _root.queryArea(areaToQuery, new List<T>());
        }

        public override void checkChildren() {}
    }
}
