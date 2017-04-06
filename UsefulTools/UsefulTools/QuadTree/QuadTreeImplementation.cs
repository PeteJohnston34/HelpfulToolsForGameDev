using Microsoft.Xna.Framework;
using System;

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

        public override void print(string indent = "")
        {
            Console.WriteLine("Tree Contents:");
            _root.print(indent);
        }
    }
}
