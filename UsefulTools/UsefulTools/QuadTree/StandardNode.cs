using Microsoft.Xna.Framework;
using System;

namespace UsefulTools.QuadTree
{
    class StandardNode<T> : Node<T>
    {
        //Members
        private StandardNode<T>[] _children; //Quadrants are organized in the following order: {Nw, Ne, Sw, Se}
        private Node<T> _parent;
        private Rectangle _rectangle;
        private T _entity;

        //Properties
        public bool HasChildren { get; set; }
        public bool HasEntity { get { return _entity != null; } }
        public override Rectangle Rect { get { return _rectangle; } }

        //Constructor
        public StandardNode(Rectangle rectangle, Node<T> parent)
        {
            _children = new StandardNode<T>[4];
            _parent = parent;
            _rectangle = rectangle;
            HasChildren = false;
        }

        //Public Methods
        public override void add(T entity)
        {       
            if (!HasEntity)
            {
                _entity = entity;
            }
            else
            {
                if (!HasChildren) { createChildren(); }
                IHasRect entityRect = (IHasRect)entity;

                for (int i = 0; i < _children.Length; i++)
                {
                    if(_children[i]._rectangle.Intersects(entityRect.Rect))
                    {
                        _children[i].add(entity);
                        break;
                    }
                }
            }
        }

        public override void print(string indent)
        {
            Console.WriteLine(indent + ToString());

            if (HasChildren)
            {
                indent += " - ";
                for (int i = 0; i < _children.Length; i++)
                {
                    _children[i].print(indent);
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            if (HasEntity)
            {
                s += ("Entity # " + _entity.GetHashCode() + " ");
            }

            s += ("Quad Rectangle: " + _rectangle.ToString());

            return s;
        }

        //Private Methods
        private void createChildren()
        {
            HasChildren = true;

            Point size = new Point(_rectangle.Width / 2, _rectangle.Height / 2);
            Rectangle nwRect = new Rectangle(_rectangle.Location, size);
            Rectangle neRect = new Rectangle(new Point(_rectangle.Center.X, _rectangle.Location.Y), size);
            Rectangle swRect = new Rectangle(new Point(_rectangle.Location.X, _rectangle.Center.Y), size);
            Rectangle seRect = new Rectangle(_rectangle.Center, size);

            _children[0] = new StandardNode<T>(nwRect, this);
            _children[1] = new StandardNode<T>(neRect, this);
            _children[2] = new StandardNode<T>(swRect, this);
            _children[3] = new StandardNode<T>(seRect, this);
        }
    }
}
